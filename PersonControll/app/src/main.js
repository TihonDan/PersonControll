import { createApp } from 'vue';
import App from './App';
import useVuelidate from '@vuelidate/core';
import component from '@/components/UI';
import {vsButton, Vuesax, vsInput} from 'vuesax3'
import {SetupCalendar}from 'v-calendar'

import 'vuesax3/dist/vuesax.css'
import 'v-calendar/dist/style.css'

const app = createApp(App);

component.forEach(component => {
    app.component(component.name, component)
});

app.mount('#app');

app.use(Vuesax, {
     theme:{
         colors:{
           primary:'#5b3cc4',
           success:'rgb(23, 201, 100)',
           danger:'rgb(242, 19, 93)',
           warning:'rgb(255, 130, 0)',
           dark:'rgb(36, 33, 69)'
         }
     }
});

app.use(SetupCalendar, {})

app.use(vsButton);

app.use(vsInput);

app.use(useVuelidate);
