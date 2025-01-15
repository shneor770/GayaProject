const port = '7084';
const apiUrl = `https://localhost:${port}/api/gaya/ActionCalculate/`
const loadOperations = 'loadOperations';
const calculate = 'calculate';


loadAllOperations();


async function loadAllOperations() {
    const response = await fetch(`${apiUrl}${loadOperations}`)
        .then(response => {
            if (!response.ok) {
                console.log('err', response);
            }
            return response.json();
        })
        .then(data => {
            const operations = data;
            const operationSelect = document.getElementById('operation');
            operations.forEach(op => {
                const option = document.createElement('option');
                option.value = op;
                option.textContent = op;
                operationSelect.appendChild(option);
            });
        })
        .catch(err => {
            console.log('err', err);
        });
}
async function calculateAction() {
    const feild1 = parseFloat(document.getElementById('feild1').value);
    const feild2 = parseFloat(document.getElementById('feild2').value);
    const operation = document.getElementById('operation').value;

    var isValid = isValidData(feild1, feild2, operation);

    if (isValid) {
        const response = await fetch(`${apiUrl}${calculate}`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ feild1, feild2, operation })
        });

        const result = await response.json();

        document.getElementById('result').className = "alert alert-success child";
        document.getElementById('result').innerHTML = `
                                                    <b>תוצאה</b>
                                                    <span>${result.res}</span>`;

        if (result.lastAction != null) {
            const historyContainer = document.getElementById('lastActions');
            historyContainer.innerHTML = '<b>3 פעולות אחרונות</b>';

            result.lastAction.forEach(a => {
                const actionElement = document.createElement('div');
                actionElement.innerHTML = `
                                            <span>${a.result}</span>
                                            <span>=</span>
                                            <span>${a.feild2}</span>
                                            <span>${a.operations}</span>
                                            <span>${a.feild1}</span>
        `;
                historyContainer.className = "child alert alert-success";
                historyContainer.appendChild(actionElement);
            });
        }

        document.getElementById('countOperationsPerMonth').innerHTML = `
                                                    <b>כמות פעולות חודש נוכחי</b>
                                                    <span>${result.currentMonth}</span>`;
        document.getElementById('countOperationsPerMonth').className = "child alert alert-success";


        document.getElementById('minMaxAvg').className = "mt3 col-12 text-center alert alert-warning";

        const min = `<div class="col-4">הנמוך ביותר ${result.minMaxAvg.min}</div>`;
        const max = `<div class="col-4">הגבוה ביותר ${result.minMaxAvg.max}</div>`;
        const avg = `<div class="col-4">ממוצע ${result.minMaxAvg.avg}</div>`;

        document.getElementById('minMaxAvg').innerHTML = min + max + avg;
    }
    document.getElementById('feild1').value = "";
    document.getElementById('feild2').value = "";
}


function isValidData(feild1, feild2, oprate) {
    const err = document.getElementById('error');

    if ((oprate == 'Divide' || oprate == 'Modulo') && feild2 == 0) {
        err.className = "alert alert-danger";
        err.textContent = "לא ניתן לבצע ב0";
        return false;
    }

    if ((isNaN(feild1) || isNaN(feild2))) {
        err.className = "alert alert-danger";
        err.textContent = "אחד משדות החישוב ריקים";
        return false;
    }
    err.className = "";
    err.textContent = "";
    return true;
}



