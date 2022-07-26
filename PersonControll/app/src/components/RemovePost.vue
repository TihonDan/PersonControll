<template>
    <!--Изменение пользователя-->
    <div v-if="show" class="modal-shadow">
        <my-draggable>
            <template v-slot:header>
                <my-button class="create" @click="closeModal">&#10006;</my-button>
            </template>
            <template v-slot:main>
                <div class="modal-content">
                    <form @submit.prevent>
                        <h2>Изменить</h2>
                        <my-input class="input" type="text" placeholder="Имя" v-model="Surname" />
                        <my-input class="input" type="text" placeholder="Фамилия" v-model="Lastname" />
                        <my-input class="input" type="text" placeholder="Отчество" v-model="Firstname" />
                        <DatePicker v-model="Birthday">
                            <template v-slot="{ inputValue, inputEvents }">
                                <my-input class="input" :value="inputValue" v-on="inputEvents"
                                    placeholder="Дата рождения" />
                            </template>
                        </DatePicker>
                    </form>
                </div>
            </template>
            <template v-slot:footer>
                <div class="modal-footer">
                    <my-button @click="showRemoveWarning">Изменить</my-button>
                </div>
            </template>
        </my-draggable>
        <remove-warning ref="modal" :id="this.id" :surname="Surname" :lastname="Lastname" :firstname="Firstname"
            :birthday="Birthday" @closeAllModal="closeAll__Modal"></remove-warning>
        <NullExitSelected ref="nullExitSelected" @closeAllModal="closeAll__Modal"></NullExitSelected>
    </div>
</template>

<script>
import removeWarning from './Warning/RemoveWarning.vue'
import { DatePicker } from 'v-calendar';
import NullExitSelected from './Warning/nullExitSelected.vue';


export default {
    components: {
        removeWarning,
        DatePicker,
        NullExitSelected,
    },
    name: "ModalWindow",
    data: function () {
        return {
            show: false,
            Surname: null,
            Firstname: null,
            Lastname: null,
            Birthday: null
        }
    },
    methods: {
        closeModal: function () {
            if (this.Surname !== null || this.Firstname !== null || this.Lastname !== null || this.Birthday !== null) {
                this.$refs.nullExitSelected.show = true;
            }
            else {
                this.$emit('active');
                this.show = false
                this.Surname = null;
                this.Firstname = null;
                this.Lastname = null;
                this.Birthday = null;
            }
        },
        closeAll__Modal() {
            this.$emit('active');
            this.show = false
        },
        exitRemove(show) {
            this.show = show;
        },
        showRemoveWarning() {
            this.$refs.modal.show = true;
        },
    },
    props: {
        id: String
    }
}
</script>

<style scoped,
    lang="scss">
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
        margin-top: -50px;
        background: rgba(0, 0, 0, 0);
    }
    </style>

