import { http } from "./config";

export default {
  get: id => {
    return http.get(`/api/exame/${id}`);
  },
  getAll: () => {
    return http.get(`/api/exame/`);
  },
  post: obj => {
    return http.post(`/api/exame/`, obj);
  },
  put: obj => {
    return http.put(`/api/exame/`, obj);
  }
};
