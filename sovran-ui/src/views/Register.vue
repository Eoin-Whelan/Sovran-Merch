<template>
<div class="about">
  <form @submit.prevent="submitForm">
    <div>
      <label for="username">Username:</label><br>
      <input id="username" type="text" v-model="username" required/>
    </div>
    <div>
      <label for="email">Password:</label><br>
      <input id="email" type="text" v-model="password" required/>
    </div>
    <button  type="submit">Submit</button>
    <div>
      <h3>Data retrieved from server:</h3>
      //<p v-if="success"> {{ success }}</p>
      <p>{{ response }}</p>
    </div>
  </form>
  <registration-form>
  </registration-form>
</div>
</template>

<script>
// :class="[name ? activeClass : '']"
import axios from 'axios';
import Registration from '../components/forms/Registration.vue'

export default({
  name: 'Registration',
  props: {
    Registration
  },
  data () {
    return {
      username: '',
      password: '',
      response: '',
      success : '',
      info: null
    }
  },
  methods: {
    submitForm() {
      console.log(this.username);

      axios({
        headers: {"Access-Control-Allow-Origin": "*"},
        method: 'POST',
        url: '/RegisterAccount',
        params: {
          //form : {
            Username : this.username,
            Password : this.password
//          }
        }
        }).then(response => {
          this.success = 'Data Saved';
          this.response = JSON.stringify(response, null,2)
        })
      }
    }
})

</script>