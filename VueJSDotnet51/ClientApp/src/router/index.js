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
import EditHome from "../components/EditHome.vue";
import EditInfo1 from "../components/EditInfo1.vue";
import EditInfo2 from "../components/EditInfo2.vue";
import EditInfo3 from "../components/EditInfo3.vue";
import EditInfo4 from "../components/EditInfo4.vue";



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
        path: "/EditHome",
        name: "EditHome",
        component: EditHome,
    },
    {
        path: "/EditInfo1",
        name: "EditInfo1",
        component: EditInfo1,
    },
    {
        path: "/EditInfo2",
        name: "EditInfo2",
        component: EditInfo2,
    },
    {
        path: "/EditInfo3",
        name: "EditInfo3",
        component: EditInfo3,
    },
    {
        path: "/EditInfo4",
        name: "EditInfo4",
        component: EditInfo4,
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