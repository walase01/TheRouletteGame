import axios from 'axios';
import { Usuario } from '@/models/usuario.model';
import { AppResponse } from '../models/response.model';


// const API_URL = 'https://localhost:8090/api/Usuario'; // test
const API_URL = 'https://localhost:7093/api/Usuario'; // local

export const usuarioService = {

  async obtenerSaldo(nombre: string): Promise<AppResponse<Usuario>> {
    try {
      const response = await axios.get<AppResponse<Usuario>>(`${API_URL}/GetUserByName/${nombre}`);
      return response.data;
    } catch (error: any) {
      return {
        succeeded: false,
        message: 'Error al obtener el saldo del usuario',
        errors: [
          {
            code: error.response?.status || 500,
            message: error.message || 'Error desconocido',
          },
        ],
      };
    }
  },

  async guardarSaldo(usuario: Usuario): Promise<AppResponse<string> | null> 
  {
    try {
      const response = await axios.post<AppResponse<string>>(`${API_URL}/AddNewUserOrAddAmount`, usuario);
      return response.data;
    } catch (error: any) 
    {
      return {
        succeeded: false,
        message: 'Error al guardar el saldo',
        errors: [
          {
            code: error.response?.status || 500,
            message: error.message,
          },
        ],
      };
    }
  }
  
}
