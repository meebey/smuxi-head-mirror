# automake magic variables
if INSTALL_PKG_CONFIG
pkgconfigdir = $(libdir)/pkgconfig
pkgconfig_DATA = $(ASSEMBLY_PC).pc
endif
# end of magic

RAW_API=$(ASSEMBLY_NAME)-api.raw
API=$(ASSEMBLY_NAME)-api.xml
METADATA=$(ASSEMBLY_NAME).metadata
KEYFILE=$(top_srcdir)/$(ASSEMBLY_NAME).snk
sources = 

build_sources = AssemblyInfo.cs $(sources)

customs = 

CLEANFILES = $(ASSEMBLY_NAME).dll generated-stamp generated/*.cs $(API)

DISTCLEANFILES = AssemblyInfo.cs $(ASSEMBLY_PC).pc stamp-h

noinst_DATA = $(ASSEMBLY_NAME).dll

EXTRA_DIST = $(RAW_API) $(sources) $(customs) $(METADATA) \
	AssemblyInfo.cs.in \
	$(ASSEMBLY_NAME).snk \
	$(ASSEMBLY_NAME).dll.config \
	$(ASSEMBLY_NAME).pc.in

all: generated-stamp $(ASSEMBLY)

$(API): $(srcdir)/$(RAW_API) $(srcdir)/$(METADATA)
	cp $(srcdir)/$(RAW_API) $(API)
	chmod u+w $(API)
	$(GAPI_FIXUP) --api=$(API) --metadata=$(srcdir)/$(METADATA)

generated-stamp: $(API)
	 $(GAPI_CODEGEN) --generate $(API) \
		$(GTK_SHARP_CFLAGS) \
		$(GIO_SHARP_CFLAGS) \
	 	--outdir=generated --customdir=$(srcdir) \
	 	--assembly-name=$(ASSEMBLY_NAME) && touch generated-stamp

$(ASSEMBLY_NAME).dll: $(build_sources) generated-stamp
	$(CSC) -nowarn:169 -unsafe -target:library -keyfile:$(KEYFILE) \
		$(GTK_SHARP_LIBS) \
		$(GIO_SHARP_LIBS) \
		$(build_sources)  generated/*.cs -out:$(ASSEMBLY_NAME).dll

if INSTALL_PKG_GAC
install-data-local:
	echo "$(GACUTIL) /i $(ASSEMBLY_NAME).dll /f $(GACUTIL_FLAGS)";  \
        $(GACUTIL) /i $(ASSEMBLY_NAME).dll /f $(GACUTIL_FLAGS) || exit 1;

uninstall-local:
	echo "$(GACUTIL) /u $(ASSEMBLY_NAME) $(GACUTIL_FLAGS)"; \
        $(GACUTIL) /u $(ASSEMBLY_NAME) $(GACUTIL_FLAGS) || exit 1;
endif
