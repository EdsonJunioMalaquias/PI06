import { http } from "./config";

export default {
  get: id => {
    return http.get(`/api/tipoProcedimento/${id}`);
  },
  getAll: () => {
    return http.get(`/api/tipoProcedimento/`);
  },
  post: obj => {
    return http.post(`/api/tipoProcedimento/`, obj);
  },
  put: obj => {
    return http.put(`/api/tipoProcedimento/`, obj);
  }
};
