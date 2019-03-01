import Vue from 'vue'
import Router from 'vue-router'
import Forecast from './views/Forecast.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'forecast',
      component: Forecast
    },
    {
      path: '/history',
      name: 'history',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './views/History.vue')
    },
    { path: '*', component: () => import('./views/NotFound.vue') }
  ]
})
