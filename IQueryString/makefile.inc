# Updates the imported IL from UIAutomationClient.tlb
# 1. Convert UIAutomationClient.IRawElementProviderSimple to the right namespace

#
# tlbimp doesn't like using a temporary file with a different name
# so we can't do the usual del, make .temp, move
# instead produce the file in a temp directory
# It is annoying for keep forming $(@D)\temp\$(@B).extension, so we instead
# cd to $(@D)\temp and then use just $(@B).extension.
#


$(OBJ_PATH)\$O\$(TARGETNAME).dll: $(TLBIMP_SOURCE) 
    set BUILDMSG3=making $(@F) (tlbimp $(?F), ildasm, perl, ilasm)

	cd $(@D)
	if exist $(@F) del $(@F)
	if exist temp rmdir /q/s temp
	mkdir temp
	cd temp

    tlbimp.cmd \
        $** \
        $(TLBIMP_FLAGS) \
	/out:$(@F)
	
    del $(@B).pdb	
    ildasm.exe \
        $(@F) \
 	/out=$(@B).il \
        /nobar

    del $(@F)
    
    del $(@B).il.bak

    ilasm.exe \
       	$(@B).dll \
	/dll \
	/debug=opt \
        /keyfile:$(PUBLIC_INTERNAL_PATH)\StrongNameKeys\fake\WindowsClientTestUntrusted.snk \
        /output=$(@F)

	del \
	$(@B).il \
	$(@B).res \

    move $(@B).pdb ..
    move $(@F) ..

    cd $(MAKEDIR)
    rmdir $(@D)\temp

$(OBJ_PATH)\$O\$(TARGETNAME).metadata_dll: $(@D)\$(@B).dll
    set BUILDMSG3=making $(@F) (copy $(?F) $(@F))
    copy $? $@

