import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

import 'bootstrap/dist/css/bootstrap.min.css'
import 'animate.css'

import Vue3Toastify, { type ToastContainerOptions } from 'vue3-toastify/dist/index';

createApp(App).use(router).mount('#app')

App.use(Vue3Toastify, {
    autoClose: 3000,
  } as ToastContainerOptions);