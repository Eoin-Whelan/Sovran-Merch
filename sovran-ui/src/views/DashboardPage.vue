<template>
<div class="container">
  <div class="columns">
    <div class="column">
      <div class="box">
          <Login :show='showLogin' @successfulLogin="isValid"></Login>
          <Dashboard :authorized="validLogin"></Dashboard>
      </div>
    </div>
  </div>
</div>
</template>

<script>

import Dashboard from '../components/dashboard/Dashboard.vue'
import Login from '../components/forms/Login.vue'
    export default {
        name:'DashboardPage',
        components: {
            Dashboard,
            Login
        },
        data() {
            return {
                showLogin: true,
                validLogin: false,
                userInformation : null
            }
        },
        methods: {
          isValid(){
              this.validLogin = true
              this.showLogin = false

          }
        }
    }
</script>
