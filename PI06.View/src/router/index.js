import Vue from 'vue'
import Router from 'vue-router'
import Busca from '@/components/Busca'
import Login from '@/components/Login'


Vue.use(Router)

export default new Router({
    routes: [
        {
            path: '/busca',
            name: 'Busca',
            component: Busca
        },
        {
            path: '/login',
            name: 'Login',
            component: Login
        }

    ]
})