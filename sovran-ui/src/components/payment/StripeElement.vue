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
export default {
  components: {
    StripeElementPayment,
  },
  data () {
    return {
      pk: 'pk_test_51K9bu8Dj019cdYs2D4iOslhZF4gKV0elbRhMi2hJ9OoWGUfCg307JculshrLEhsJagbzCKobroAlY6ClZKEFdEG500EmK2xS1z',
      elementsOptions: {
        appearance: {}, // appearance options
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
      const paymentIntent = await apiCallToGeneratePaymentIntent(); // this is just a dummy, create your own API call
      this.elementsOptions.clientSecret = paymentIntent.client_secret;
    }
    pay () {
      this.$refs.paymentRef.submit();
    },
  },
};
</script>