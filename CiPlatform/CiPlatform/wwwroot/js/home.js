//grid list view change 

function showGrid() {
    gridbtn = document.getElementById("grid-btn");
    gridContainer = document.getElementById("gridContainer");
    listContainer = document.getElementById("listContainer")
    gridContainer.style.display = "block";
    listContainer.classList.add("d-none");
    console.log("grid button pressed ");
}

function showList() {
    listbtn = document.getElementById("list-btn");
    gridContainer = document.getElementById("gridContainer");
    listContainer = document.getElementById("listContainer");
    gridContainer.style.display = "none";
    listContainer.classList.remove("d-none");
    console.log("list btn pressed");
}

//post a comment function


function postComment() {
    let input = document.getElementById("comments").value;
    console.log(input);
    if (input == "") {
        alert("comment should not be empty");
    } else {
        let newComment = document.createElement("div");
        newComment.className = "card mb-2 w-100";
        newComment.innerHTML = `<div class="card-body d-flex">
    <img
      class="rounded-circle"
      src="./Assets/volunteer1.png"
      alt="Avatar"
      style="width: 50px; height: 50px"
    />
    <div class="px-4">
      <h6 class="card-title">Margeret walse</h6>
      <p class="card-text">
        Monday, October 21 2019, 4:57 PM
      </p>
      <p>${input}</p>
    </div>
  </div>`;

        let parentcommentLi = document.getElementById("parentcomment");
        parentcommentLi.appendChild(newComment);
        document.getElementById("comments").value = "";
        document.getElementById("comments").focus();
    }
}
