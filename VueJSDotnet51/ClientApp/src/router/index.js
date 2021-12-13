import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Login from "@/components/Login.vue";
import Priklocaties from "@/components/Priklocaties.vue";
import SecureComponent from "@/components/Secure.vue"
import Info from "@/components/Info.vue"
import AddReservation from "@/components/AddReservation.vue";
import PDF from "../components/PDF.vue";
import EditorArjan from "../components/EditorArjan.vue";

const routes = [
    {
        path: "/Home",
        name: "Home",
        component: Home,
    },
    {
        path: "/Login",
        name: "Login",
        component: Login, 
    },
    {
        path: "/PDF",
        name: "PDF",
        component: PDF,

    },
    {
        path: "/Secure",
        name: "Secure",
        component: SecureComponent,
    },
    {
        path: "/Priklocaties",
        name: "Priklocaties",
        component: Priklocaties,
    },
    {
        path: "/Info",
        name: "Info",
        component: Info,
    },
    {
        path: "/AddReservation",
        name: "AddReservation",
        component: AddReservation,
    },
    {
        path: "/EditorArjan",
        name: "EditorArjan",
        component: EditorArjan,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;