<template>
  <div class="wrapper" :class="{ 'nav-open': $sidebar.showSidebar }">
    <notifications></notifications>

    <side-bar>
      <mobile-menu slot="content"></mobile-menu>
      <sidebar-link to="/listaespera">
        <md-icon>list</md-icon>
        <p>Lista de espera</p>
      </sidebar-link>
      <sidebar-link to="/consulta">
        <md-icon>person</md-icon>
        <p>Consulta </p>
      </sidebar-link>
      <sidebar-link to="/usuario">
        <md-icon>content_paste</md-icon>
        <p> Usuarios</p>
      </sidebar-link>

      
      <sidebar-link to="/cadastropessoa">
        <md-icon>person</md-icon>
        <p>Cadastro Pessoa</p>
      </sidebar-link>
      <sidebar-link to="/relatorio">
        <md-icon>person</md-icon>
        <p>Relatório </p>
      </sidebar-link>


    </side-bar>

    <div class="main-panel">
      <top-navbar></top-navbar>

      <dashboard-content> </dashboard-content>

      <content-footer v-if="!$route.meta.hideFooter"></content-footer>
    </div>
  </div>
</template>
<style lang="scss"></style>
<script>
import TopNavbar from "./TopNavbar.vue";
import ContentFooter from "./ContentFooter.vue";
import DashboardContent from "./Content.vue";
import MobileMenu from "@/pages/Layout/MobileMenu.vue";

export default {
  components: {
    TopNavbar,
    DashboardContent,
    ContentFooter,
    MobileMenu
  }
};
</script>
