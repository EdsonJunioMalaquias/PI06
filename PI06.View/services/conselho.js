import { http } from "./config";

export default {
  get: id => {
    return http.get(`/api/conselho/${id}`);
  },
  getAll: () => {
    return http.get(`/api/conselho/`);
  },
  post: obj => {
    return http.post(`/api/conselho/`, obj);
  },
  put: obj => {
    return http.put(`/api/conselho/`, obj);
  }
};
