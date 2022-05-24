import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import Buefy from 'buefy'
import 'buefy/dist/buefy.css'
import * as VeeValidate from 'vee-validate'
import { StripePlugin } from '@vue-stripe/vue-stripe';

Vue.config.productionTip = false

const options = {
  pk: "pk_test_51K9bu8Dj019cdYs2D4iOslhZF4gKV0elbRhMi2hJ9OoWGUfCg307JculshrLEhsJagbzCKobroAlY6ClZKEFdEG500EmK2xS1z", // process.env.STRIPE_PUBLISHABLE_KEY,
  stripeAccount: 'acct_1K2zJnE91ud3hB1x',
  apiVersion: '2020-08-27',
  locale: process.env.LOCALE,
};
Vue.use(Buefy, VeeValidate);
Vue.use(StripePlugin, options);
new Vue({
  router,
  store,
  
  render: h => h(App)
}).$mount('#app')
