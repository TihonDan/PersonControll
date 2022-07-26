<template>
    <div v-if="show" class="modal-shadow">
        <div>
            <my-draggable :disabled="!isActive">
                <template v-slot:header>
                    <vsButton color="danger" type="gradient" class="create" @click="closeModal" :disabled="!isActive">
                        &#10006;</vsButton>
                </template>
                <template v-slot:main>
                    <div class="modal-content">
                        <form @submit.prevent>
                            <h3>Поиск</h3>
                            <my-input v-model="Surname" class="input" type="text" placeholder="Имя"
                                :disabled="!isActive" />
                            <my-input v-model="Firstname" class="input" type="text" placeholder="Фамилия"
                                :disabled="!isActive" />
                            <my-input v-model="Lastname" class="input" type="text" placeholder="Отчество"
                                :disabled="!isActive" />
                            <DatePicker v-model="FirstBirthday" :disabled="isActive">
                                <template v-slot="{ inputValue, inputEvents }">
                                    <my-input class="input" :value="inputValue" v-on="inputEvents" placeholder="Дата от"
                                        :disabled="!isActive" />
                                </template>
                            </DatePicker>
                            <p>{{LastBirthday}}</p>
                            <DatePicker v-model="LastBirthday" :disabled="isActive">
                                <template v-slot="{ inputValue, inputEvents }">
                                    <my-input class="input" :value="inputValue" v-on="inputEvents" placeholder="Дата до"
                                        :disabled="!isActive" />
                                </template>
                            </DatePicker>
                        </form>
                    </div>
                </template>
                <template v-slot:footer>
                    <vs-button type="gradient" class="create" @click="fetchSearch" :disabled="!isActive">Поиск
                    </vs-button>
                </template>
            </my-draggable>
        </div>
        <nullUsers ref="warnModal"></nullUsers>
        <post-list ref="modal" :users="users" @closeModal="active" :Surname="Surname" :Firstname="Firstname" :Lastname="Lastname" :FirstBirthday="FirstBirthday" :LastBirthday="LastBirthday"></post-list>
    </div>
</template>

<script>
import PostList from "./PostList";
import axios from 'axios';
import nullUsers from '@/components/Warning/nullUsers.vue'
import { DatePicker } from 'v-calendar';

import 'v-calendar/dist/style.css';

export default {
    components: {
        PostList,
        nullUsers,
        DatePicker
    },
    name: "ModalWindow",
    data: function () {
        return {
            show: false,
            Surname: '',
            Firstname: '',
            Lastname: '',
            FirstBirthday: '',
            LastBirthday: '',
            newFB: '',
            newLB: '',
            users: [],
            isActive: true,
        }
    },
    methods: {
        closeModal: function () {
            this.show = false
            this.Firstname = '',
                this.Lastname = '',
                this.Surname = '',
                this.FirstBirthday = '',
                this.LastBirthday = ''
        },
        async fetchSearch() {
            const formatDate = (date) => {
                let d = new Date(date);
                let month = (d.getMonth() + 1).toString();
                let day = d.getDate().toString();
                let year = d.getFullYear();
                if (month.length < 2) {
                    month = '0' + month;
                }
                if (day.length < 2) {
                    day = '0' + day;
                }
                return [day, month, year].join('.');
            }
            try {
                if (formatDate(this.FirstBirthday) == '' || this.FirstBirthday == '') {
                    this.newFB = '01.01.0001';
                } else { this.newFB = '' }
                if (formatDate(this.LastBirthday) == '' || this.LastBirthday == '') {
                    this.newLB = '01.01.0001';
                } else { this.newLB = '' }

                if (this.FirstBirthday !== '') { this.FirstBirthday = formatDate(this.FirstBirthday) }

                if (this.LastBirthday !== '') { this.LastBirthday = formatDate(this.LastBirthday) }

                const responce = await axios.get('https://localhost:44310/Search/GetData?surname=' +
                    this.Surname + '&firstname=' + this.Firstname +
                    '&lastname=' + this.Lastname + '&firstBirthday=' +
                    this.FirstBirthday + this.newFB + '&lastBirthday=' + this.LastBirthday + this.newLB + '');
                this.users = responce.data.persons;
                this.$refs.modal.show = true;
                console.log(responce);
            }
            catch (e) {
                this.$refs.warnModal.show = true;
            }

            if (this.isActive == true) {
                this.isActive = false;
            } else { this.isActive == true }
        },
        // async _print() {
        //     const formatDate = (date) => {
        //         let d = new Date(date);
        //         let month = (d.getMonth() + 1).toString();
        //         let day = d.getDate().toString();
        //         let year = d.getFullYear();
        //         if (month.length < 2) {
        //             month = '0' + month;
        //         }
        //         if (day.length < 2) {
        //             day = '0' + day;
        //         }
        //         return [day, month, year].join('.');
        //     }
        //     try {
        //         if (formatDate(this.FirstBirthday) == '' || this.FirstBirthday == '') {
        //             this.newFB = '01.01.0001';
        //         } else { this.newFB = '' }
        //         if (formatDate(this.LastBirthday) == '' || this.LastBirthday == '') {
        //             this.newLB = '01.01.0001';
        //         } else { this.newLB = '' }

        //         if (this.FirstBirthday !== '') { this.FirstBirthday = formatDate(this.FirstBirthday) }

        //         if (this.LastBirthday !== '') { this.LastBirthday = formatDate(this.LastBirthday) }

        //         const responce = await axios.get('https://localhost:44310/FastReport/GetReport?surname=' +
        //             this.Surname + '&firstname=' + this.Firstname +
        //             '&lastname=' + this.Lastname + '&firstBirthday=' +
        //             this.FirstBirthday + this.newFB + '&lastBirthday=' + this.LastBirthday + this.newLB + '');
        //         this.users = responce.data.persons;
        //         this.$refs.modal.show = true;
        //         console.log(responce);
        //     }
        //     catch (e) {
        //         this.$refs.warnModal.show = true;
        //     }
        // },
        active() {
            this.isActive = true
        }
    }
}
</script>

<style scoped>
form {
    display: flex;
    flex-direction: column;
}

.modal-shadow {
    position: absolute;
    top: 50%;
    left: 50%;
    width: 500px;
    height: 300px;
    margin-left: -250px;
    margin-top: -250px;
    background: rgba(0, 0, 0, 0);
}
</style>

