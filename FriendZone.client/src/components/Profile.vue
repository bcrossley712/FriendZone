<template>
  <div class="shadow">
    <div class="row rounded-top">
      <div class="col-12 bg-img min-height bg-light d-flex justify-content-end">
        <i
          @click.stop="createFollow"
          v-if="following?.length == 0"
          class="mdi mdi-star-outline text-grey fs-1"
        ></i>
        <i
          @click.stop="deleteFollow"
          v-else
          class="mdi mdi-star text-danger fs-1"
        ></i>
      </div>
    </div>
    <div class="row rounded-bottom bg-grey">
      <div class="col-12 d-flex justify-content-between">
        <span class="fw-bold">{{ profile.name }}</span>
        <span>
          <i class="mdi mdi-account-multiple text-danger me-1"></i
          >{{ profile.followers?.length }}
        </span>
      </div>
      <div class="col-12">
        <span class="fw-bold">Likes: {{ profile.likes }}</span>
      </div>
    </div>
  </div>
</template>


<script>
import { computed, ref } from "@vue/reactivity"
import Pop from "../utils/Pop"
import { logger } from "../utils/Logger"
import { AppState } from "../AppState"
import { onMounted, watchEffect } from "@vue/runtime-core"
import { profilesService } from "../services/ProfilesService"
import { followsService } from "../services/FollowsService";
export default {
  props: {
    profile: {
      type: Object,
      required: true
    }
  },
  setup(props) {

    return {
      backgroundImage: computed(() => `url('${props.profile.picture}')`),
      following: computed(() => AppState.myProfile?.following.filter(p => p.id == props.profile.id)),
      async createFollow() {
        try {
          const data = { following: props.profile.id }
          await followsService.createFollow(data)
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      async deleteFollow() {
        try {
          await followsService.deleteFollow(props.profile.id)
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.bg-img {
  background-image: v-bind(backgroundImage);
  background-position: center;
  background-size: cover;
  min-height: 25vw;
  border-top-left-radius: 3px;
  border-top-right-radius: 3px;
}
</style>