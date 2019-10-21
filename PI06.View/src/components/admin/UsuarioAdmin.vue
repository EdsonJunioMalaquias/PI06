<template>
    <div class="usuario-admin">
       
    </div>
</template>

<script>
//import {baseApiUrl} from '@/global'
import axios from 'axios'


export default {
    name: 'UsuarioAdmin',
    data: function(){
        return{
            mode: 'save',
            user:{},
            users: []
        }
    },
    methods: {
        loadUsers(){
            const url = `${baseApiUrl}/users`
            axios.get(url).then(res => {
                this.users = res.data
            })
        }
    },
    mounted(){
        this.loadUsers()
    }

    
}
</script>
<style scoped>

</style>