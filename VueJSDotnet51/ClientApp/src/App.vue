<template>
    <div id="app">
        <div id="nav">
            <router-link v-if="authenticated" to="/login" v-on:click="logout()" replace>Logout</router-link>
        </div>
        <nav-menu></nav-menu>
        <router-view @authenticated="setAuthenticated" />
    </div>
</template>

<script>
    import NavMenu from './components/NavMenu.vue'

export default {
        name: 'App',
        emits: ["authenticated" , "setAuthenticated"],
  components: {
      NavMenu
        },
        data() {
            return {
                authenticated: false,
                mockAccount: {
                    username: "Test",
                    password: "Test"
                }
            }
        },
        mounted() {
            if (!this.authenticated) {
                this.$router.replace({ name: "Login" });
            }
        },
        methods: {
            setAuthenticated(status) {
                this.authenticated = status;
            },
            logout() {
                this.authenticated = false;
            }
        }
    }
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
