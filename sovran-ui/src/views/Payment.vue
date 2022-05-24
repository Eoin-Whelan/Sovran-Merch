<template>
  <div>
    <stripe-element-payment
      ref="paymentRef"
      :pk="pk"
      :elements-options="elementsOptions"
      :confirm-params="confirmParams"
    />
    <button @click="pay">Pay Now</button>
  </div>
</template>

<script>
import { StripeElementPayment } from '@vue-stripe/vue-stripe';
import axios from 'axios';

export default {
  components: {
    StripeElementPayment,
  },
  //props: [pk, elementsOptions, confirmParams],
  data () {
    return {
      pk: 'pk_test_51K9bu8Dj019cdYs2D4iOslhZF4gKV0elbRhMi2hJ9OoWGUfCg307JculshrLEhsJagbzCKobroAlY6ClZKEFdEG500EmK2xS1z',
      elementsOptions: {
        appearance: {
          theme: 'stripe'
        }, // appearance options
      },
      confirmParams: {
        return_url: 'http://localhost:8080/success', // success url
      },
    };
  },
  mounted () {
    this.generatePaymentIntent();
  },
  methods: {
    async generatePaymentIntent () {
      axios({
        headers: {"Access-Control-Allow-Origin": "*"},
        method: 'post',
        url: '/CreateIntent',
        params: {
        }
        }).then(response => {
          console.log(response);
          this.elementsOptions.clientSecret = JSON.stringify(response, null,2)
        })
      //const paymentIntent = await apiCallToGeneratePaymentIntent(); // this is just a dummy, create your own API call
      //this.elementsOptions.clientSecret = "pi_3KlvJODj019cdYs22GzcCnLf_secret_v1frOoyoIQtAbqja8DOMU34ak";
    },
    pay () {
      this.$refs.paymentRef.submit();
    },
  },
};
</script>