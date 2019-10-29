import Vue from 'vue'
import App from './App.vue'
import router from './router'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
Vue.use(BootstrapVue)

import VueMask from 'v-mask'
Vue.use(VueMask);

import Vuex from 'vuex'
Vue.use(Vuex)

import Gravatar from 'vue-gravatar';
Vue.component('v-gravatar', Gravatar);

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
  
}).$mount('#app')
