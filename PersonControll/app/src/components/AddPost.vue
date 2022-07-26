<template >
    <div v-if="show" class="modal-shadow">
        <div>
            <my-draggable>
                <template v-slot:header>
                    <my-button class="create" @click="closeModal">&#10006;</my-button>
                </template>
                <template v-slot:main>
                    <div class="modal-content">
                        <form @submit.prevent="submitHandler">
                            <my-input v-model.trim="form.Surname" type="text" placeholder="Имя" class="input" />
                            <my-input v-model="form.Firstname" class="input" type="text" placeholder="Фамилия" />
                            <my-input v-model="form.Lastname" class="input" type="text" placeholder="Отчество" />
                            <DatePicker v-model="form.Birthday">
                                <template v-slot="{ inputValue, inputEvents }">
                                    <my-input class="input" :value="inputValue" v-on="inputEvents"
                                        placeholder="Дата Рождения(ДД/ММ/ГГГГ)" @input="numbersOnly" />
                                </template>
                            </DatePicker>
                        </form>
                    </div>
                </template>
                <template v-slot:footer>
                    <div class="modal-footer">
                        <my-button class="create" @click="fetchSearch" type="submit">Добавить</my-button>
                    </div>
                </template>
            </my-draggable>
            <NotAdd ref="modal"></NotAdd>
            <YesAdd ref="yesModal" @closeAllModal="closeAll__Modal"></YesAdd>
            <NullExitAdd ref="nullExitModal" @closeAllModal="closeAll__Modal"></NullExitAdd>
            <NullAdd ref="nullAdd" @closeAllModal="closeAll__Modal"></NullAdd>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import NotAdd from './Warning/notAdd.vue'
import YesAdd from './Warning/YesAdd.vue'
import { DatePicker } from 'v-calendar';

import 'v-calendar/dist/style.css';
import NullExitAdd from './Warning/nullExitAdd.vue';
import NullAdd from './Warning/nullAdd.vue';


export default {
    components: {
        NotAdd,
        YesAdd,
        DatePicker,
        NullExitAdd,
        NullAdd,
    },
    name: "ModalWindow",
    data: function () {
        return {
            show: false,
            form: {
                Surname: null,
                Firstname: null,
                Lastname: null,
                Birthday: null,
            }
        }
    },
    methods: {
        closeModal: function () {
            if (this.form.Surname !== null || this.form.Firstname !== null || this.form.Lastname !== null || this.form.Birthday !== null) {
                this.$emit('closeAllModal');
                this.$refs.nullExitModal.show = true;
            }
            else {
                this.form.Surname = null;
                this.form.Firstname = null;
                this.form.Lastname = null;
                this.form.Birthday = null;
                this.show = false
            }
            this.form.Surname = null;
            this.form.Firstname = null;
            this.form.Lastname = null;
            this.form.Birthday = null;
        },
        closeAll__Modal() {
            this.$emit('closeAllModal')
            this.show = false
        },
        async fetchSearch() {
            if (this.form.Surname == null || this.form.Firstname == null || this.form.Lastname == null || this.form.Birthday == null) {
                this.$refs.nullAdd.show = true;
            }
            else {
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
                    const responce = await axios.post('https://localhost:44310/EditTableColumn/AddColumn?surname=' + this.form.Surname + '&firstname=' + this.form.Firstname + '&lastname=' + this.form.Lastname + '&birthday=' + formatDate(this.form.Birthday) + '');
                    console.log(responce);
                    this.form.Surname = null;
                    this.form.Firstname = null;
                    this.form.Lastname = null;
                    this.form.Birthday = null;
                    this.$refs.yesModal.show = true;
                }
                catch (e) {
                    this.$refs.modal.show = true;
                }
            }
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

.fon {
    background-color: #fff;
}
</style>

