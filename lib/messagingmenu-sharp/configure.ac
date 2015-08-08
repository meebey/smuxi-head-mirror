AC_INIT([messagingmenu-sharp], [1.0.1])
AC_CONFIG_SRCDIR([README])
AC_CANONICAL_TARGET
AM_INIT_AUTOMAKE
AM_MAINTAINER_MODE
AC_PROG_INSTALL

dnl Package settings
ASSEMBLY_COMPANY=""
ASSEMBLY_COPYRIGHT="2012 (C) Mirco Bauer <meebey@meebey.net>"
ASSEMBLY_DESCRIPTION="MessagingMenu-1.0 bindings for Mono"
ASSEMBLY_NAME="messagingmenu-sharp"
ASSEMBLY_NAMESPACE="MessagingMenu"
ASSEMBLY_PC="messagingmenu-sharp"
ASSEMBLY_SHORTNAME="messagingmenu"
ASSEMBLY_TITLE="MessagingMenu"
ASSEMBLY_VERSION="12.10.3"
AC_SUBST([ACLOCAL_AMFLAGS], ["-I m4 \${ACLOCAL_FLAGS}"])

AC_SUBST(ASSEMBLY_NAME)
AC_SUBST(ASSEMBLY_VERSION)
AC_SUBST(ASSEMBLY_NAMESPACE)
AC_SUBST(ASSEMBLY_SHORTNAME)
AC_SUBST(ASSEMBLY_TITLE)
AC_SUBST(ASSEMBLY_DESCRIPTION)
AC_SUBST(ASSEMBLY_COMPANY)
AC_SUBST(ASSEMBLY_COPYRIGHT)
AC_SUBST(ASSEMBLY_PC)

dnl Check for pkg-config
AC_PATH_PROG(PKG_CONFIG, pkg-config, no)
if test "x$PKG_CONFIG" = "xno"; then
	AC_MSG_ERROR(['pkg-config' is not in your PATH.])
fi

AC_PATH_PROG(WHICH, which, no)
if test "x$WHICH" = "xno"; then
	AC_MSG_ERROR(['which' is not in your PATH.])
fi

dnl Check for Mono
PKG_CHECK_MODULES(MONO_DEPENDENCY, mono >= 1.0, has_mono=true, has_mono=false)

if test "x$has_mono" = "xtrue"; then
	AC_PATH_PROG(RUNTIME, mono, no)
	AC_PATH_PROG(CSC, gmcs, no)
	LIB_PREFIX=.so
	LIB_SUFFIX=
else
	AC_PATH_PROG(CSC, csc.exe, no)
	if test x$CSC = "xno"; then
		AC_MSG_ERROR([You need to install either mono or .Net])
	else
		RUNTIME=
		LIB_PREFIX=
		LIB_SUFFIX=.dylib
	fi
fi

CS="C#"
if test "x$CSC" = "xno" ; then
    AC_MSG_ERROR([No $CS compiler found])
fi

AC_PATH_PROG(GACUTIL, gacutil, no)
if test "x$GACUTIL" = "xno" ; then
	AC_MSG_ERROR([No gacutil tool found])
fi

GACUTIL_FLAGS="/package $ASSEMBLY_NAME /root "'$(DESTDIR)$(prefix)/lib'

AC_ARG_ENABLE(pkg-config,
	AC_HELP_STRING([--disable-pkg-config],
		[Disable pkg-config install [default=NO]]),
	disable_pkg_config=yes, disable_pkg_config=no
)
AM_CONDITIONAL([INSTALL_PKG_CONFIG], test x$disable_pkg_config = xno)

AC_ARG_ENABLE(pkg-gac,
	AC_HELP_STRING([--disable-pkg-gac],
		[Disable GAC install [default=NO]]),
	disable_pkg_gac=yes, disable_pkg_gac=no
)
AM_CONDITIONAL([INSTALL_PKG_GAC], test x$disable_pkg_gac = xno)
                                     
AC_SUBST(RUNTIME)
AC_SUBST(CSC)
AC_SUBST(GACUTIL)
AC_SUBST(GACUTIL_FLAGS)
AC_SUBST(LIB_PREFIX)
AC_SUBST(LIB_SUFFIX)

dnl Check for gtk-sharp
PKG_CHECK_MODULES(GTK_SHARP, gtk-sharp-2.0)
AC_SUBST(GTK_SHARP_CFLAGS)
AC_SUBST(GTK_SHARP_LIBS)
gtksharp_prefix=`pkg-config --variable=prefix gtk-sharp-2.0`
AC_SUBST(gtksharp_prefix)

dnl Check for gio-sharp
PKG_CHECK_MODULES(GIO_SHARP, gio-sharp-2.0)
AC_SUBST(GIO_SHARP_CFLAGS)
AC_SUBST(GIO_SHARP_LIBS)

dnl Check for gapi
AC_PATH_PROG(GAPI_PARSER, gapi2-parser, no)
if test "x$GAPI_PARSER" = "xno"; then
	AC_MSG_CHECKING(for gapi2-parser.exe)
	GAPI_PARSER=`$WHICH gapi2-parser.exe`
	if test "x$GAPI_PARSER" = "x" ; then
		AC_MSG_ERROR(['gapi2-parser'/'gapi2-parser.exe' not found.])
	fi
	AC_MSG_RESULT($GAPI_PARSER)
	GAPI_PARSER="$MONO $GAPI_PARSER"
fi
AC_SUBST(GAPI_PARSER)

AC_PATH_PROG(GAPI_FIXUP, gapi2-fixup, no)
if test "x$GAPI_FIXUP" = "xno"; then
	AC_MSG_CHECKING(for gapi2-fixup.exe)
	GAPI_FIXUP=`$WHICH gapi2-fixup.exe`
	if test "x$GAPI_FIXUP" = "x" ; then
		AC_MSG_ERROR(['gapi2-fixup'/'gapi2-fixup.exe' not found.])
	fi
	AC_MSG_RESULT($GAPI_FIXUP)
	GAPI_FIXUP="$MONO $GAPI_FIXUP"
fi
AC_SUBST(GAPI_FIXUP)

AC_PATH_PROG(GAPI_CODEGEN, gapi2-codegen, no)
if test "x$GAPI_CODEGEN" = "xno"; then
	AC_MSG_CHECKING(for gapi2_codegen.exe)
	GAPI_CODEGEN=`$WHICH gapi2_codegen.exe`
	if test "x$GAPI_CODEGEN" = "x" ; then
		AC_MSG_ERROR(['gapi2-codegen'/'gapi2_codegen.exe' not found.])
	fi
	AC_MSG_RESULT([$GAPI_CODEGEN])
	GAPI_CODEGEN="$MONO $GAPI_CODEGEN"
fi
AC_SUBST(GAPI_CODEGEN)

dnl Check for monodoc
AC_PATH_PROG(MDASSEMBLER, mdassembler, no)
AC_PATH_PROG(MONODOCER, monodocer, no)
if test "x$MONODOCER" = "xno" -o "x$MDASSEMBLER" = "xno"; then
	enable_monodoc=no
	doc_sources_dir=
else
	enable_monodoc=yes
	doc_sources_dir="`pkg-config --variable=sourcesdir monodoc`"
fi
AC_SUBST(MDASSEMBLER)
AC_SUBST(MONODOCER)

AM_CONDITIONAL(ENABLE_MONODOC, test "x$enable_monodoc" = "xyes")
dnl Check for MessagingMenu
PKG_CHECK_MODULES(MESSAGINGMENU, messaging-menu)
messagingmenu_prefix=/usr
AC_SUBST(messagingmenu_prefix)



AC_CONFIG_FILES([
	Makefile
	AssemblyInfo.cs
	messagingmenu-sharp.pc
])
AC_CONFIG_COMMANDS([default],[[ echo timestamp > stamp-h ]],[[]])
AC_OUTPUT

echo ""
echo "Configuration summary"
echo "---------------------"
echo ""
echo "   * Installation prefix: $prefix"
echo "   * compiler: $CSC"
echo "   * Documentation:  ($MONODOC)"
echo ""
