
    var AncestorsCount = 0;
    var DescendantsLevel = 0;
    var AncestorName = '';
    var DescendantsArr = [];
    var DescendantsTreeViewArr = [];
    var AncestorLastBrotherlvl = 0;
    var execludeditems = [];
var ultext = '<ul>';
    var Accounts = [];
    var Parents = [];
var DisplayNames = [];
function fnbuildtreeview(pBranchList, pRootlist, pElement, pDisplayNamelist) {
        Accounts = pBranchList;
        Parents = pRootlist;
        DisplayNames = pDisplayNamelist;
        for (var i = 0; i < Accounts.length; i++) {
            if (Parents[i] == '0') {
                var vlevelsofparent = getlevelsforparent(Accounts[i]);
                ultext += '<li data-id = ' + Accounts[i] + '><a href="#" class="clsTree" Account-No=' + DisplayNames[i]+'  data-id=' + Accounts[i] + '>' + DisplayNames[i] + "</a>"

               
                if (vlevelsofparent > 0) {
                    //have childs
                    ultext += '<ul>'
          
                }
                else {

                    //have no Branches
                    if (Parents[i] == '0') {
                        // Direct Root
                        ultext += '</li>'
                    }
                }
                GetDirectChilds(Accounts[i]);
                execludeditems.push(Accounts[i]);

            }
            else {

            }
        }

        ultext += '</ul>'
        pElement.append(ultext);
        //pElement.filetree();
       
    }

    function GetDirectChilds(vParent) {
        var LstDirectChilds = []
        var vlevelsofparents = 0;
        if (jQuery.inArray(vParent, execludeditems) == -1) {
            if (vParent != '0') {
                vlevelsofparents = getlevelsforparent(vParent);
            }
            for (var s = 0; s < Accounts.length; s++) {
                if (jQuery.inArray(vParent, execludeditems) == -1) {

                    if (Parents[s] == vParent) {
                        ultext += '<li data-id = ' + Accounts[s] + '><a href="#" data-id = ' + Accounts[s] + '>' + DisplayNames[s]
                        ultext += '</a>'
                        //console.log("child of Parent " + vParent + " is " + Accounts[s]);
                        LstDirectChilds.push(vParent);

                        if (getlevelsforparent(Accounts[s]) > 0) {
                            //have childs
                            ultext += '<ul>'
                            //console.log('parentz -' + Accounts[s] + 'childz number' + vlevelsofparent);

                        }
                        else {

                            //have no Branches
                            if (vParent != '0') {
                                // Is Not direct Root
                                ultext += '</li>'
                                // Check if The Current Branch Is The Last One In Order If 0 Then true
                                if (CheckIfLastBrother(Accounts[s]) == 0) {
                                    GetAncestorName(Accounts[s]);
                                    GetDescendantByTreeViewOrder(AncestorName);
                                    // Check If Child Is The last one in Order
                                    if (DescendantsTreeViewArr[DescendantsTreeViewArr.length - 1] == Accounts[s]) {
                                        // Child Is The last one in Order
                                        GetAncestorsNumber(Accounts[s]);
                                        AncestorsCount;
                                        for (var u = 0; u < AncestorsCount; u++) {
                                            ultext += '</ul>'
                                            ultext += '</li>'

                                        }
                                    }
                                    else if (DescendantsTreeViewArr[DescendantsTreeViewArr.length - 1] != Accounts[s]) {
                                        // Child Is Not The last one in Order
                                        GetAncestorLastBrotherLevel(Accounts[s]);
                                        for (var n = 0; n < AncestorLastBrotherlvl; n++) {
                                            ultext += '</ul>'
                                            ultext += '</li>'
                                        }
                                        AncestorLastBrotherlvl = 0;
                                    }

                                }
                          
                                DescendantsTreeViewArr = [];
                                AncestorName = '';
                                DescendantsLevel = 0;
                                AncestorsCount = 0;
                            }
                            else if (vParent = '0') {
                                // Is Not direct Root
                                ultext += '</li>'
                            }

                        }
                        //ultext += vParent ;
                        ultext.replace(/\n/g, "<br />");
                        GetDirectChilds(Accounts[s]);
                        execludeditems.push(Accounts[s]);


                    }
                }

            }
        }
    }
    function getlevelsforparent(vParents2) {
        var levelforparent = 0
        for (var w = 0; w < Accounts.length; w++) {
            if (Parents[w] == vParents2) {
                levelforparent++;

            }
        }
        //console.log(" Parent  No " + vParents2 + "  Levels is = " + levelforparent)
        return levelforparent;
    }
    function GetAncestorsNumber(vChilds) {

        for (var h = 0; h < Accounts.length; h++) {
            if (Accounts[h] == vChilds) {
                if (Parents[h] == '0') {

                    break;
                }
                if (Parents[h] != '0') {
                    AncestorsCount++;

                    GetAncestorsNumber(Parents[h]);
                }


            }
        }

    }

    function getfirstDirectChild(pParent) {
        for (var g = 0; g < Accounts.length; g++) {
            if (Parents[g] == pParent) {
                DescendantsLevel++;
                break;
            }
        }
    }
    function GetDecsendantsLevel(PAncestor) {
        for (var j = 0; j < Accounts.length; j++) {

            if (Parents[j] == PAncestor) {
                getfirstDirectChild(PAncestor)

            }
            if (Parents[j] != PAncestor) {
                GetAncestorName(Accounts[j])
                if (PAncestor == AncestorName) {
                    AncestorName = '';
                    getfirstDirectChild(Accounts[j]);

                }
            }
        }
    }
    function GetAncestorName(vChilds) {

        for (var k = 0; k < Accounts.length; k++) {
            if (Accounts[k] == vChilds) {
                if (Parents[k] == '0') {
                    AncestorName = Accounts[k]
                    break;
                }
                if (Parents[k] != '0') {

                    GetAncestorName(Parents[k]);
                }


            }
        }
    }
    function GetDescendantByOrder(pAncestorName) {
        for (var v = 0; v < Accounts.length; v++) {
            // If Direct Child
            if (Parents[v] == pAncestorName) {
                DescendantsArr.push(Accounts[v])
                if (getlevelsforparent(Accounts[v]) > 0) {
                    // have  childs 
                }

            }
            // ELSE If NOT Direct Child
            else if (Parents[v] != pAncestorName && Parents[v] != '0') {
                // Get Ancestor Name
                GetAncestorName(Accounts[v]);
                // check The Ancestor Name Of The Child
                if (pAncestorName == AncestorName) {
                    DescendantsArr.push(Accounts[v]);
                    AncestorName = '';
                }

            }
        }

    }
    function GetDescendantByTreeViewOrder(pAncestorName) {
        for (var q = 0; q < Accounts.length; q++) {
            // If Direct Child
            if (Parents[q] == pAncestorName) {
                DescendantsTreeViewArr.push(Accounts[q]);
                GetDescendantByTreeViewOrder(Accounts[q]);
              
            }
           
        }


    }
    // check If it is the last branch in order
    function CheckIfLastBrother(PChild) {
        var vBranches = 0;
        if (Accounts.indexOf(PChild) + 1 <= Accounts.length) {
            for (var t = Accounts.indexOf(PChild) + 1; t < Accounts.length; t++) {
                if (Parents[t] == Parents[Accounts.indexOf(PChild)]) {
                    // not last brother
                    vBranches += 1;
                }
                else {

                }
            }
        }

        return vBranches;
    }

    function GetAncestorLastBrotherLevel(pChild) {

        for (var e = 0; e < Accounts.length; e++) {
            if (Accounts[e] == pChild) {
                if (Parents[e] == '0') {
                    break;
                }
                if (Parents[e] != '0') {
                    if (CheckIfLastBrother(Parents[e]) == 0) {
                        // Parent Is The Last Brother
                        AncestorLastBrotherlvl += 1;
                        GetAncestorLastBrotherLevel(Parents[e])

                    }
                    else if (CheckIfLastBrother(Parents[e]) != 0) {
                        // Parent Not The Last Brother
                        AncestorLastBrotherlvl += 1;
                        break;

                    }
                }
            }
        }

    }






