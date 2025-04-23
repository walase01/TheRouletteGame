<template>
    <div class="container animate__animated animate__zoomIn">
      <h2 style="text-align: center;">The Roulette Game</h2>
  
      <div v-if="!juegoIniciado" class="card p-4">
        <input v-model="nombre" class="form-control mb-2" placeholder="Nombre" />
        <input v-model.number="saldo" type="number" class="form-control mb-2" placeholder="Saldo" />
        <button @click="iniciarJuego" class="btn btn-success me-2">Iniciar</button>
        <button @click="cargarSaldo" class="btn btn-info">Cargar</button>
      </div>
  
      <div v-else class="card p-4 mt-3">
        <p>Jugador: {{ nombre }} | Saldo: {{ saldo }}</p>
        <input v-model.number="apuesta" type="number" class="form-control mb-2" placeholder="Apuesta" />
        <select v-model="tipoApuesta" class="form-select mb-2">
          <option value="rojo">Rojo</option>
          <option value="negro">Negro</option>
          <option value="par-rojo">Par Rojo</option>
          <option value="par-negro">Par Negro</option>
          <option value="impar-rojo">Impar Rojo</option>
          <option value="impar-negro">Impar Negro</option>
          <option value="numero">Número + Color</option>
        </select>
  
        <div v-if="tipoApuesta === 'numero'" class="mb-2">
          <input v-model.number="numeroApostado" type="number" class="form-control"/>
          <select v-model="colorApostado" class="form-select">
            <option value="rojo">Rojo</option>
            <option value="negro">Negro</option>
          </select>
        </div>
  
        <button @click="jugar" class="btn btn-primary me-2">Jugar</button>
        <button @click="guardarSaldo" class="btn btn-warning">Guardar</button>
  
        <div v-if="resultadoTexto" class="alert alert-info mt-3 animate__animated animate__bounceIn">
          {{ resultadoTexto }}
        </div>
      </div>
    </div>
  </template>
  
  <script setup lang="ts">

  import { ref } from 'vue'
  import { toast } from 'vue3-toastify';
  import 'vue3-toastify/dist/index.css';
  import { usuarioService } from '../services/usuario.service';
  import { gamblingService } from '../services/gambling.service';
  import { Usuario } from '@/models/usuario.model';
import { gamblingrequest } from '../models/gamblingrequest.model';

  const nombre = ref('')
  const saldo = ref(0)
  const apuesta = ref(0)
  const isLoading = ref(false);
  const tipoApuesta = ref('rojo')
  const numeroApostado = ref(-1)
  const colorApostado = ref('rojo')
  const juegoIniciado = ref(false)
  const resultadoTexto = ref('')
  
  const iniciarJuego = () => {
    juegoIniciado.value = true
  }
  
  const cargarSaldo = async () => {
    const data = await usuarioService.obtenerSaldo(nombre.value)
    if (data.succeeded) {
      toast.success(`Usuario encontrado ${data.result?.user} :) Monto ${data.result?.amount}`);
      saldo.value = data.result?.amount ?? 0
      juegoIniciado.value = true
    } else {
      toast.error(data?.message);
    }
  }
  
  const guardarSaldo = async () => {
    const usuario: Usuario = {
      user : nombre.value,
      amount: saldo.value
    }
    var saveUserInfo = await usuarioService.guardarSaldo(usuario);
    if(saveUserInfo?.succeeded){
      toast.success(saveUserInfo.result);
    }
    else{
      toast.error(saveUserInfo?.message);
    }
  }
  
  const jugar = async  () => {

    isLoading.value = false;

    if(numeroApostado.value !== -1){
      if(numeroApostado !== null && (numeroApostado.value < 0 || numeroApostado.value > 36)){
        toast.error(`El numero tiene que estar en el rando de 0 a 36`)
        return;
    }
    }

    if (apuesta.value > saldo.value) {
        console.log("test",toast);        
        toast.error("Saldo Insuficiente", {
        autoClose: 1000,
      });
      return
    }

    let _type : string | null;

    if(tipoApuesta.value === 'par-rojo'){
      _type = 'par';
      colorApostado.value = 'rojo';
    }
    else if(tipoApuesta.value === 'impar-negro'){
      _type = 'impar';
      colorApostado.value = 'negro';
    }
    else if (tipoApuesta.value === 'rojo'){
      _type = null;
      colorApostado.value = 'rojo';
    }
    else if (tipoApuesta.value === 'negro'){
      _type = null;
      colorApostado.value = 'negro';
    }
    else if (tipoApuesta.value === 'par-negro'){
      _type = 'par';
      colorApostado.value = 'negro';
    }
    else if (tipoApuesta.value === 'impar-rojo'){
      _type = 'impar';
      colorApostado.value = 'rojo';
    }
    else{
      _type = null;
    }

  
    var request : gamblingrequest = {
      user : nombre.value,
      color : colorApostado.value,
      amount : apuesta.value,
      number : numeroApostado.value,
      type : _type,
      userAmount : saldo.value
    };

    var infoOfTheGame = await gamblingService.jugar(request);
  if(infoOfTheGame.succeeded){
    if (infoOfTheGame.result?.successful) {
      toast.success(`GANASTE : ${infoOfTheGame.result?.award}`);
      saldo.value =  infoOfTheGame.result?.userAmount ? infoOfTheGame.result.userAmount : 0;
      resultadoTexto.value = infoOfTheGame.message ?? ''
    } else {
      toast.warning(`PERDISTE : ${infoOfTheGame.result?.award}`);
      saldo.value =  infoOfTheGame.result?.userAmount ? infoOfTheGame.result.userAmount : 0;
      resultadoTexto.value = infoOfTheGame.message ?? ''
    }
  }
  else{

  }

    isLoading.value = true;
  }
  </script>
  