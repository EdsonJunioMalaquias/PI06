import Vue from 'vue'
import Router from 'vue-router'
import Busca from '@/components/Busca'
import Login from '@/components/Login'
import Auth from '@/components/auth/Auth'
import Home from '@/components/home/Home'
import AdminPages from '@/components/admin/AdminPages'
import novaConsulta from '@/components/consulta/NewConsulta'


Vue.use(Router)

export default new Router({
    routes: [
        {
            path: '/',
            name: 'Login',
            component: Login
        },
        {
            path: '/busca',
            name: 'Busca',
            component: Busca
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
        }
    ]
})