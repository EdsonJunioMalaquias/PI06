import { http } from './config'

export default {
    get:(cpf) => {
        return http.get(`/api/funcionario/cpf/${cpf}`)
    },    
    get:(id) => {
        return http.get(`/api/funcionario/${id}`)
    }, 
    get:() => {
        return http.get(`/api/funcionario/`)
    },
    post:(obj) => {
        return http.post(`/api/funcionario/`,obj)
    },
    put:(obj) => {
        return http.post(`/api/funcionario/`,obj)
    },
    autenticar:(obj) => {
        return http.post(`/api/auth/entrar`,obj)
    },
    novaConta:(obj) => {
        return http.post(`api/Auth/nova-conta`,obj)
    },
}   