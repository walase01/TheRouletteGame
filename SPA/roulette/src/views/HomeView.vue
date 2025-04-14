<template>
  <div class="home">
    <div class="home-description" style="max-width: 800px; margin: auto; padding: 2rem; background: #1e1e1e; border-radius: 1rem; color: #fff;">
  <h1 style="text-align: center; color: #ffcc00;">El Juego de la Ruleta</h1>
  <p>
    Diseñar una vista o interfaz gráfica en <strong>Vue.js 3</strong> que tenga las siguientes características:
  </p>
  <ol>
    <li><strong>Diseño libre</strong> (Se recomienda implementar inicialmente la lógica del juego).</li>
    <li>
      La vista debe tener un botón que permita al usuario empezar el juego declarando un monto inicial como su saldo y una apuesta;
      o cargando su saldo respectivo usando su nombre para poder realizar una apuesta.
    </li>
    <li>
      Al iniciar el juego se debe mostrar el resultado de la ruleta, tanto el número obtenido, como si fue par/impar, rojo o negro.
    </li>
    <li>
      El usuario debe poder apostar ya sea por: un <strong>color</strong>, los <strong>pares o impares de un color dado</strong> o a un
      <strong>número y color específicos</strong>.
    </li>
    <li>
      Se debe tener un mecanismo que le permita al usuario <strong>apostar y saber si ha ganado o no</strong> a la apuesta realizada,
      mostrando el resultado obtenido en la ruleta.
    </li>
    <li>
      El usuario tendrá un botón donde pueda <strong>guardar y asignar el monto ganado a su nombre</strong>.
    </li>
    <li>
      Si el usuario decide no guardar su partida, se <strong>perderán los datos</strong> una vez se cierre la ventana.
    </li>
    <li>
      Debe existir un botón que permita <strong>cargar el saldo de un usuario a partir de un nombre</strong>.
      (En caso de existir un juego en curso que no ha sido guardado, se perderán los datos del juego en curso y serán sobrescritos por el nuevo jugador).
    </li>
  </ol>
</div>

  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'HomeView',
  components: {
  },
});
</script>
