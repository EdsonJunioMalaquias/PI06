import Vue from 'vue'
import Router from 'vue-router'
import BuscaPaciente from '@/components/BuscaPaciente'
import Login from '@/components/Login'
import Auth from '@/components/auth/Auth'
import Home from '@/components/home/Home'
import AdminPages from '@/components/admin/AdminPages'
import novaConsulta from '@/components/consulta/NewConsulta'
import Espera from '@/components/Espera'
import CadastroPessoaForm from '@/component/UserProfile/CadastroPessoaForm'
import Relatorio from "@/pages/Relatorio.vue"



Vue.use(Router)

export default new Router({
    routes: [
        {
            path: '/',
            name: 'Login',
            component: Login
        },
        {
            path: '/buscapaciente',
            name: 'BuscaPaciente',
            component: BuscaPaciente
        },
        {
            path: '/auth',
            name: 'Auth',
            component: Auth
        },
        {
            path: '/home',
            name: 'Home',
            component: Home
        },
        {
            path: '/adminpages',
            name: 'AdminPages',
            component: AdminPages
        },
        {
            path: '/novaConsulta',
            name: 'Consulta',
            component: novaConsulta
        },
        {
            path: '/espera',
            name: 'Espera',
            component: Espera
        },
        {
            path: '/cadastropessoa',
            name: 'Cadastro de Pessoas',
            component: CadastroPessoaForm
        },
        {
            path: "relatorio",
            name: "Relatorio",
            component: Relatorio
          }
    ]
})