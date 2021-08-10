function createAssemblyLine(){
    return{
        hasClima: (car) => {
            car.temp = 21;
            car.tempSettings = 21;
            car.adjustTemp = () => {
                if (cat.temp < car.tempSettings) {
                    car.temp++;
                }else if (car.temp > car.tempSettings) {
                    car.temp--;
                }
            };
        },
        hasAudio: (car) => {
            car.currentTrack = {
                name: '',
                artist: '',                
            };
            car.nowPlaying = () => {
                if (car.currentTrack !== null) {                   
                    console.log(`Now playing ${car.currentTrack.name} by ${car.currentTrack.artist}`);
                }
            }
        },
        hasParktronic: (car) => {
            car.checkDistance = (distance) => {
                let signal ='';
                if (distance < 0.1) {
                    signal = 'Beep! Beep! Beep!';
                }else if (distance >= 0.1 && distance < 0.25) {
                    signal = 'Beep! Beep!';
                }else if (distance >= 0.25 && distance < 0.5) {
                    signal = 'Beep!';
                }
                console.log(signal);
            }
        }
    };
}


