import { http } from "./config";

export default {
  getByCpf: cpf => {
    return http.get(`/api/funcionario/cpf/${cpf}`);
  },
  getbById: id => {
    return http.get(`/api/funcionario/id/${id}`);
  },
  get: () => {
    return http.get(`/api/funcionario/`);
  },
  getbyCargo: cargo => {
    return http.get(`/api/funcionario/${cargo}`);
  },
  post: obj => {
    return http.post(`/api/funcionario/`, obj);
  },
  put: obj => {
    return http.put(`/api/funcionario/`, obj);
  },
  autenticar: obj => {
    return http.post(`/api/auth/entrar`, obj);
  },
  novaConta: obj => {
    return http.post(`api/Auth/nova-conta`, obj);
  }
};
