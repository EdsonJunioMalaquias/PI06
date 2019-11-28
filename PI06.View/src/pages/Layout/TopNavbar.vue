<template>
  <md-toolbar md-elevation="0" class="md-transparent">
    <div class="md-toolbar-row">
      <div class="md-toolbar-section-start">
        <h3 class="md-title">{{ $route.name }}</h3>
      </div>
      <div class="md-toolbar-section-end">
        <md-button
          class="md-just-icon md-simple md-toolbar-toggle"
          :class="{ toggled: $sidebar.showSidebar }"
          @click="toggleSidebar"
        >
          <span class="icon-bar"></span>
          <span class="icon-bar"></span>
          <span class="icon-bar"></span>
        </md-button>

        <div class="md-collapse">
          <div class="md-autocomplete">
            <md-autocomplete class="search" v-model="selectedEmployee" :md-options="employees">
              <label>Pesquisar</label>
            </md-autocomplete>
          </div>
          <md-list>
    
            <li class="md-list-item">
              <a
                href="#/notifications"
                class="md-list-item-router md-list-item-container md-button-clean dropdown"
              ></a>
            </li>

            <md-list-item>
              <md-icon class="material-icons">person</md-icon>
              <p class="hidden-lg hidden-md">Perfil</p>
            </md-list-item>
          </md-list>
        </div>
      </div>
    </div>
  </md-toolbar>
</template>

<script>
export default {
  data() {
    return {
      selectedEmployee: null,
      employees: []
    };
  },
  methods: {
    toggleSidebar() {
      this.$sidebar.displaySidebar(!this.$sidebar.showSidebar);
    }
  }
};
</script>

<style lang="css"></style>
