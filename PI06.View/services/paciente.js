import { http } from "./config";

export default {
  getByCpf: cpf => {
    return http.get(`/api/paciente/cpf/${cpf}`);
  },
  get: id => {
    return http.get(`/api/paciente/${id}`);
  },
  getAll: () => {
    return http.get(`/api/paciente/`);
  },
  post: obj => {
    return http.post(`/api/paciente/`, obj);
  },
  put: obj => {
    return http.put(`/api/paciente/`, obj);
  }
};
