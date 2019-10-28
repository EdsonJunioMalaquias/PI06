import { http } from './config'

export default {
    get:(id) => {
        return http.get(`/api/consulta/${id}`)
    }, 
    get:() => {
        return http.get(`/api/consulta/`)
    },
    post:(obj) => {
        return http.post(`/api/consulta/`,obj)
    },
    put:(obj) => {
        return http.post(`/api/consulta/`,obj)
    }
}