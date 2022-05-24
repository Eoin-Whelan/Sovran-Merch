import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
//import Storefront from '../views/Storefront.vue'
//import Payment from '../views/Payment.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/Dashboard',
    name: 'DashboardPage',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "Login" */ '../views/DashboardPage.vue')
  },
  {
    path: '/Register',
    name: 'Register',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "Login" */ '../views/Register.vue')
  },
  {
    path: '/Payment',
    name: 'Payment',
    component: () => import(/* webpackChunkName: "Login" */ '../views/Payment.vue')
  },
  {
    path: '/Payment',
    name: 'Storefront',
    component: () => import(/* webpackChunkName: "Payment" */ '../views/Payment.vue')
  },
  {
    path: '/:id',
    name: 'Storefront',
    component: () => import(/* webpackChunkName: "Storefront" */ '../views/Storefront.vue')
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
