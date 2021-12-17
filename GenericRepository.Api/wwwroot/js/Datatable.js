<script type="text/javascript">
    fetch("https://localhost:44304/api/company/getall").then(
res => {
        res.json().then(
            data => {
                console.log(data);
                if (data.length > 0) {



                    var temp = "";
                    data.forEach((itemData) => {
                        temp += "<tr>";
                        temp += "<td>" + itemData.companyNumber + "</td>";
                        temp += "<td>" + itemData.companyName + "</td>";
                        temp += "<td>" + itemData.address + "</td>";
                        temp += "<td>" + itemData.creatingDate + "</td>";
                        temp += "<td>" + itemData.updatedDate + "</td>";
                        temp += "<td>" + itemData.isActive + "</td></tr>";
                    });
                    document.getElementById('output').innerHTML = temp;
                }
            }
        )
    }
    )
</script>