import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Login from "@/components/Login.vue";
import Priklocaties from "@/components/Priklocaties.vue";
import SecureComponent from "@/components/Secure.vue"
import Info1 from "@/components/Info1.vue"
import Info2 from "@/components/Info2.vue"
import Info3 from "@/components/Info3.vue"
import Info4 from "@/components/Info4.vue"
import AddReservation from "@/components/AddReservation.vue";
import PDF from "../components/PDF.vue";
import EditorArjan from "../components/EditorArjan.vue";
import EditorEsat1 from "../components/EditorEsat1.vue";
import EditorEsat2 from "../components/EditorEsat2.vue";
import EditorEsat3 from "../components/EditorEsat3.vue";
import EditorEsat4 from "../components/EditorEsat4.vue";



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
        path: "/Info1",
        name: "Info1",
        component: Info1,
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
    },
    {
        path: "/EditorEsat1",
        name: "EditorEsat1",
        component: EditorEsat1,
    },
    {
        path: "/EditorEsat2",
        name: "EditorEsat2",
        component: EditorEsat2,
    },
    {
        path: "/EditorEsat3",
        name: "EditorEsat3",
        component: EditorEsat3,
    },
    {
        path: "/EditorEsat4",
        name: "EditorEsat4",
        component: EditorEsat4,
    },
    {
        path: "/Info2",
        name: "Info2",
        component: Info2,
    },
    {
        path: "/Info3",
        name: "Info3",
        component: Info3,
    },
    {
        path: "/Info4",
        name: "Info4",
        component: Info4,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;