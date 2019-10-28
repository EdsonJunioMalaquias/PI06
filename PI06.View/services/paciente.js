import { http } from './config'

export default {
    get:(cpf) => {
        return http.get(`/api/paciente/cpf/${cpf}`)
    },    
    get:(id) => {
        return http.get(`/api/paciente/${id}`)
    }, 
    get:() => {
        return http.get(`/api/paciente/`)
    },
    post:(obj) => {
        return http.post(`/api/paciente/`,obj)
    },
    put:(obj) => {
        return http.post(`/api/paciente/`,obj)
    }
}