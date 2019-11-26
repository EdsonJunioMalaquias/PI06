import { http } from "./config";

export default {
  getByIdMedico: idMedico => {
    return http.get(`/api/fila/${idMedico}`);
  },
  getAll: () => {
    return http.get(`/api/atendimento/`);
  },
  post: obj => {
    return http.post(`/api/atendimento/`, obj);
  },
  put: obj => {
    return http.put(`/api/atendimento/`, obj);
  }
};
