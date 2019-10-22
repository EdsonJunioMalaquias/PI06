<template>
    <header class="header">
        <a class="toggle" @click="toggleMenu" v-if="!hideToggle">
            <i class="fa fa-lg" :class="icon"></i>
        </a>

        


         <ul>
            <li class="menu-item-wrapper">
                <h2 class="menu-item active"><router-link to="#">Home</router-link></h2> 
            </li>
            <li class="menu-item-wrapper">
                <h2 class="menu-item"><router-link to="/">Consulta</router-link></h2> 
            </li>
            <li class="menu-item-wrapper">
                <h2 class="menu-item"><router-link to="/">{{ title }}</router-link></h2> 
            </li>
        </ul>
    </header>
       
    
</template>

<script>
import UserDropdown from './UserDropdown'

export default {
    name: 'Header',
    components: { UserDropdown },
    props: {
        title: String,
        hideToggle: Boolean,
        hideUserDropdown: Boolean
    },
    computed: {
        icon() {
            return this.$store.state.isMenuVisible ? "fa-angle-left" : "fa-angle-down"
        }
    },
    methods: {
        toggleMenu() {
            this.$store.commit('toggleMenu')
        }
    }
}
</script>

<style>
    .menu-item-wrapper {
        float: left;
    }
    .menu-item {
        position: relative;
        padding: 5px 16px;
    }

    .menu-item:after {
        content: '';
        position: absolute;
        bottom: -1px;
        width: 0;
        height: 2px;
        background: black;
        transition: 0.2s;
    }

    .menu-item.active:after,
    .menu-item:hover:after {
    left: 0;
    width: 100%;
    }
 
    .header {
        background: linear-gradient(to right, #98a9f1, #49c167);
        display: flex;
        justify-content: center;
        margin-bottom: 2em;
        padding-top: 1em;
    }
    a:hover {
        color: #FFF;
        
        font-weight:normal;
        
        text-decoration: none;
     }
    header.header > a.toggle:hover {
        color: #fff;
        background-color: rgba(0, 0, 0, 0.2);
                
        font-weight:normal;
        
        text-decoration: none;
    }
    header.header > a.toggle {
        width: 60px;
        height: 100%;
        color: #fff;
        justify-self: flex-start;
    }
</style>
