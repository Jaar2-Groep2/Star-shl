<template>
    <div id="app">
        <div id="nav">
        </div>
        <nav-menu></nav-menu>
        <router-view @authenticated="setAuthenticated" />
        <router-link v-if="authenticated" to="/login" v-on:click="logout()" replace>
            <button class="btn">
                Logout
            </button>
        </router-link>
    </div>
</template>

<!-- <button class="btn" v-on:click="login()">Login</button> -->
    var example1 = new Vue({
        el: '#example-1',
        data: {
            counter: 0
        }
    })
<script>
    import NavMenu from './components/NavMenu.vue'
    export default {
        name: 'App',
        emits: ["authenticated", "setAuthenticated"],
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
        },
    }

</script>

<style scoped>
    .btn {
        font-size: 20px;
        color: white;
        background: #e7334c;
        border-color: #121212;
        margin-top: 100px;
    }


    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        
        background-color: #e0edf5;
    }
</style>
