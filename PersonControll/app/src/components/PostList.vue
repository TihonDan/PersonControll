<template>
    <div v-if="show" class="modal-shadow" @submit.prevent="submitHandler">
        <div>
            <my-draggable :disabled="!isActive">
                <template v-slot:header>
                    <vsButton color="danger" type="gradient" class="create" @click="closeModal" :disabled="!isActive">
                        &#10006;</vsButton>
                </template>
                <template v-slot:main>
                    <vsButton type="gradient" @click="showAddModal" :disabled="!isActive">Добавить</vsButton>
                    <vsButton color="warning" type="gradient" @click="showRemoveModal" :disabled="!isActive">Изменить
                    </vsButton>
                    <vsButton color="danger" type="gradient" @click="showDeteteWarn" :disabled="!isActive">Удалить
                    </vsButton>
                    <vsButton color="success" type="gradient" @click="print" :disabled="!isActive">Отчёт</vsButton>
                    <div>
                        <h3 class="nameTable">Список всех пользователей</h3>
                        <div class="center">
                            <table id="firstTable">
                                <thead>
                                    <tr>
                                        <th>
                                        </th>
                                        <th>Имя</th>
                                        <th>Фамилия</th>
                                        <th>Отчество</th>
                                        <th>День Рождения</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="tr in paginatedUsers" :key="tr.id_person">
                                        <td>
                                            <label class="from-checkbox">
                                                <input type="radio" :value="tr.id_person" v-model="selected"
                                                    @click="select(this)" :disabled="!isActive">
                                                <i class="form-icon"></i>
                                            </label>
                                        </td>
                                        <td>
                                            {{ tr.surname }}
                                        </td>
                                        <td>
                                            {{ tr.firstname }}
                                        </td>
                                        <td>
                                            {{ tr.lastname }}
                                        </td>
                                        <td>
                                            {{ tr.birthday }}
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </template>
                <template v-slot:footer>
                    <div class="v-table__pagination">
                        <div class="page" v-for="page in pages" :key="page" @click="pageClick(page)"
                            :disabled="!isActive">{{ page }}</div>
                    </div>
                </template>
            </my-draggable>
        </div>
        <RemovePost ref="modalRemove" :id="selected" @active="active"></RemovePost>
        <add-post ref="modal" @closeAllModal="active"></add-post>
        <DeleteWarning ref="deleteWarning" :id="selected" @active="active"></DeleteWarning>
        <NullSelected ref="nullselect" @active="active"></NullSelected>
    </div>
</template>

<script>
import AddPost from './AddPost.vue';
import RemovePost from './RemovePost.vue';
import DeleteWarning from './Warning/DeleteWarning.vue';
import NullSelected from './Warning/nullSelected.vue';
import axios from 'axios';
import fileDownload from 'js-file-download'


export default {
    components: {
        AddPost,
        RemovePost,
        DeleteWarning,
        NullSelected
    },
    name: "ModalWindow",
    data: function () {
        return {
            show: false,
            selected: '',
            usePerPage: 5,
            pageNumber: 1,
            isActive: true,
            newFB: '',
            newLB: '',
        };
    },
    methods: {
        closeModal: function () {
            this.$emit('closeModal');
            this.selected = '';
            this.show = false;
        },
        showAddModal() {
            if (this.isActive == true) {
                this.isActive = false;
            } else {
                this.isActive = true;
            }
            this.$refs.modal.show = true;
        },
        showRemoveModal() {
            if (this.selected == '') {
                this.$refs.nullselect.show = true;
                if (this.isActive == true) {
                    this.isActive = false;
                } else {
                    this.isActive = true;
                }
            } else {
                if (this.isActive == true) {
                    this.isActive = false;
                } else {
                    this.isActive = true;
                }
                this.$refs.modalRemove.show = true;
            }
        },
        showDeteteWarn() {
            if (this.selected == '') {
                this.$refs.nullselect.show = true;
                if (this.isActive == true) {
                    this.isActive = false;
                } else {
                    this.isActive = true;
                }
            } else {
                if (this.isActive == true) {
                    this.isActive = false;
                } else {
                    this.isActive = true;
                }
                this.$refs.deleteWarning.show = true;
            }
        },
        pageClick(page) {
            this.pageNumber = page;
        },
        async print() {
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

                if (this.FirstBirthday !== '') { formatDate(this.FirstBirthday) }

                if (this.LastBirthday !== '') {  formatDate(this.LastBirthday) }

                await axios.get('https://localhost:44310/FastReport/GetReport?surname=' +
                    this.Surname + '&firstname=' + this.Firstname +
                    '&lastname=' + this.Lastname + '&firstBirthday=' +
                    this.FirstBirthday + this.newFB + '&lastBirthday=' + this.LastBirthday + this.newLB + '', {
                        responseType: 'blob',
                    }).then(res => {
                        fileDownload(res.data, 'Report.pdf')
                    });
            }
            catch (e) {
                this.$refs.warnModal.show = true;
            }
        },
        active() {
            this.isActive = true;
        }
    },
    props: {
        users: {
            type: Array,
            required: true
        },
        FirstBirthday: String,
        LastBirthday: String,
        Surname: String,
        Firstname: String,
        Lastname: String
    },
    computed: {
        pages() {
            return Math.ceil(this.users.length / 5);
        },
        paginatedUsers() {
            let from = (this.pageNumber - 1) * this.usePerPage;
            let to = from + this.usePerPage;

            return this.users.slice(from, to);
        }
    }
}
</script>

<style scoped,
       lang="scss">
       .modal-shadow {
           position: absolute;
           top: 0;
           left: 0;
           min-height: 100%;
           width: 100%;
           background: rgba(0, 0, 0, 0);
       }
       
       .modalCastom {
           background: #fff;
           border-radius: 8px;
           padding: 15px;
           min-width: 600px;
           max-width: 900px;
           position: absolute;
           top: 50%;
           left: 50%;
           transform: translate(-50%, -50%);
       
           &-close {
               border-radius: 50%;
               color: #fff;
               background: #2a4cc7;
               display: flex;
               align-items: center;
               justify-content: center;
               position: absolute;
               top: 7px;
               right: 7px;
               width: 30px;
               height: 30px;
               cursor: pointer;
           }
       
           &-title {
               color: #0971c7;
           }
       
           &-content {
               margin-bottom: 20px
           }
       
           &-footer {
               &__button {
                   background-color: #0971c7;
                   color: #fff;
                   border: none;
                   text-align: center;
                   padding: 8px;
                   font-size: 17px;
                   font-weight: 500;
                   border-radius: 8px;
                   min-width: 150px;
               }
           }
       }
       
       table {
           font-family: 'Open Sans', sans-serif;
           width: 600px;
           border-collapse: collapse;
           border: 3px solid #0000ff;
           margin: 5px 5px 0 5px;
       }
       
       table th {
           text-transform: uppercase;
           text-align: left;
           background: #0000ff;
           color: #FFF;
           padding: 8px;
           min-width: 30px;
       }
       
       table td {
           text-align: left;
           padding: 8px;
           border-right: 2px solid #7D82A8;
       }
       
       table td:last-child {
           border-right: none;
       }
       
       table tbody tr:nth-child(2n) td {
           background: #D4D8F9;
       }
       
       table tbody tr td:hover {
           background: #859eb1;
           transition-duration: 0.2s;
       }
       
       .v-table__pagination {
           display: flex;
           flex-wrap: wrap;
           justify-content: center;
           margin-top: 30px;
       }
       
       .page {
           padding: 8px;
           margin-right: 10px;
           border: solid 2px #747474;
           border-radius: 4px;
       }
       
       .page:hover {
           background: #9b9b9b;
           cursor: pointer;
           color: #FFF;
       }
</style>