<template>
  <ul class="nav nav-mobile-menu">
    <li>
      <md-field>
        <label>Pesquisar</label>
        <md-input v-model="search" type="text"></md-input>
      </md-field>
    </li>
    <li>
      <a href="#" class="dropdown-toggle" data-toggle="dropdown">
        <i class="material-icons">Inicio</i>
        <p>Inicio</p>
      </a>
    </li>
    <li>
      <drop-down>
        <a slot="title" class="dropdown-toggle" data-toggle="dropdown">
          <i class="material-icons">notifications</i>
          <span class="notification">5</span>
          <p>Notificaçao</p>
        </a>
        <ul class="dropdown-menu dropdown-menu-right"></ul>
      </drop-down>
    </li>
    <li>
      <a href="#" data-toggle="dropdown" class="dropdown-toggle">
        <i class="material-icons">person</i>
        <p>Profile</p>
      </a>
    </li>
  </ul>
</template>
<script>
export default {
  data() {
    return {
      search: null,
      selectedEmployee: null,
      employees: []
    };
  }
};
</script>
