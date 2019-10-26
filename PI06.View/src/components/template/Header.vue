<template>
    <header class="header">
        <ul>
            <li class="menu-item-wrapper">
                <h2 class="menu-item active"><router-link to="/">Home</router-link></h2> 
            </li>
            <li class="menu-item-wrapper">
                <h2 class="menu-item"><router-link to="/novaConsulta/">Nova Consulta</router-link></h2> 
            </li>
        </ul>
    </header>
</template>

<script>

export default {
    name: 'Header',
    props: {
        title: String,
    },
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
        bottom: 1px;
        height: 2px;
        background: black;
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
        text-decoration: none !important;
     }


</style>
