<template>
	<div class="player">
		<div class="container">
			<div id="player-profile">
				<!--<div v-if="player.imgPath !== ''"><img src="{{ player.imgPath }}" /></div>-->
			</div>
			<div id="player-greeting">
				<h2> Welcome </h2>
			</div>
			<div id="player-name">
				<h2>{{ playerName }}</h2>
			</div>
			<div id="player-score">
				Your current score is {{ playerScore }}
			</div>
			<div class="clearfix">
			</div>
		</div>
	</div>
</template>

<style scoped>
	.container {
		align-content: left;
		align-items: left;
	}
	.clearfix::after {
	content: "";
	clear: both;
	display: table;
	}
	#player-name {
		color:slategray;
	}
	#player-greeting,#player-profile,#player-name,#player-score {
		float:left;
		margin:.5em;
	}
</style>

<script>
export default {
  name: 'Player',
  props: {
    playerName: String,
	playerScore: Number,
	person: Object
  }
}
</script>