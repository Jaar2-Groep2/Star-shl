import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Login from "@/components/Login.vue";
import SecureComponent from "@/components/Secure.vue"

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/Login",
        name: "Login",
        component: Login,
    },
    {
        path: "/Secure",
        name: "Secure",
        component: SecureComponent
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;