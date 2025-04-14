import axios from 'axios';

import { gamblingrequest } from "@/models/gamblingrequest.model";
import { AppResponse } from '../models/response.model';
import { WinInfoByUser } from "@/models/wininfobyuser.model";


const API_URL = 'https://localhost:7093/api/Gambling';

export const gamblingService = {
    async jugar(gambling: gamblingrequest): Promise<AppResponse<WinInfoByUser>> {
        try {
          const response = await axios.post<AppResponse<WinInfoByUser>>(`${API_URL}`,gambling);
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
}