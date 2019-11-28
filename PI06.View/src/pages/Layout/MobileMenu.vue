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
