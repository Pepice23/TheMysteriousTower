window.soundPlayer = {
  play: function (soundPath) {
    const audio = new Audio(soundPath);
    audio.play().catch(function (error) {
      console.log("Error playing sound: ", error);
    });
  },
};
