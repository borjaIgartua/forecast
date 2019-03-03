export default class Search {
    constructor(date, days) {
        this.date = date;
        this.city = days[0].city;
        this.days = days;        
    }

    persist() {
        var history = null;
        if (localStorage.history) {    
            history = JSON.parse(localStorage.history);                    

        } else {
            history = new Array();
        }

        if (history) {
            history.push(this);
            localStorage.history = JSON.stringify(history);
        }
    }
}