import { http } from "./config";

export default {
  get: id => {
    return http.get(`/api/procedimento/${id}`);
  },
  getAll: () => {
    return http.get(`/api/procedimento/`);
  },
  post: obj => {
    return http.post(`/api/procedimento/`, obj);
  },
  put: obj => {
    return http.put(`/api/procedimento/`, obj);
  }
};
