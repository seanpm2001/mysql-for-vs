// Copyright (c) 2004, 2013, Oracle and/or its affiliates. All rights reserved.
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License, version 2.0, as
// published by the Free Software Foundation.
//
// This program is also distributed with certain software (including
// but not limited to OpenSSL) that is licensed under separate terms,
// as designated in a particular file or component or in included license
// documentation.  The authors of MySQL hereby grant you an
// additional permission to link the program and your derivative works
// with the separately licensed software that they have included with
// MySQL.
//
// Without limiting anything contained in the foregoing, this file,
// which is part of MySQL for Visual Studio, is also subject to the
// Universal FOSS Exception, version 1.0, a copy of which can be found at
// http://oss.oracle.com/licenses/universal-foss-exception.
//
// This program is distributed in the hope that it will be useful, but
// WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU General Public License, version 2.0, for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin St, Fifth Floor, Boston, MA 02110-1301  USA

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySql.Debugger.VisualStudio
{
  static public class HRESULT
  {
    public const int S_ATTACH_DEFERRED = unchecked((int)0x40004);
    public const int S_ATTACH_IGNORED = unchecked((int)0x40005);
    public const int S_JIT_USERCANCELLED = unchecked((int)0x400B0);
    public const int S_JIT_NOT_REG_FOR_ENGINE = unchecked((int)0x400B5);
    public const int S_TERMINATE_PROCESSES_STILL_DETACHING = unchecked((int)0x400C0);
    public const int S_TERMINATE_PROCESSES_STILL_TERMINATING = unchecked((int)0x400C1);
    public const int S_ENC_SETIP_REQUIRES_CONTINUE = unchecked((int)0x40106);
    public const int S_WEBDBG_UNABLE_TO_DIAGNOSE = unchecked((int)0x40120);
    public const int S_WEBDBG_DEBUG_VERB_BLOCKED = unchecked((int)0x40121);
    public const int S_ASP_USER_ACCESS_DENIED = unchecked((int)0x40125);
    public const int S_JMC_LIMITED_SUPPORT = unchecked((int)0x40146);
    public const int S_CANNOT_REMAP_IN_EXCEPTION = unchecked((int)0x40150);
    public const int S_CANNOT_REMAP_NOT_AT_SEQUENCE_POINT = unchecked((int)0x40151);
    public const int S_GETPARENT_NO_PARENT = unchecked((int)0x40531);
    public const int S_GETDERIVEDMOST_NO_DERIVED_MOST = unchecked((int)0x40541);
    public const int S_GETMEMORYBYTES_NO_MEMORY_BYTES = unchecked((int)0x40551);
    public const int S_GETMEMORYCONTEXT_NO_MEMORY_CONTEXT = unchecked((int)0x40561);
    public const int S_GETSIZE_NO_SIZE = unchecked((int)0x40571);
    public const int S_GETEXTENDEDINFO_NO_EXTENDEDINFO = unchecked((int)0x40591);
    public const int S_ASYNC_STOP = unchecked((int)0x40B02);
    public const int E_ATTACH_DEBUGGER_ALREADY_ATTACHED = unchecked((int)0x80040001);
    public const int E_ATTACH_DEBUGGEE_PROCESS_SECURITY_VIOLATION = unchecked((int)0x80040002);
    public const int E_ATTACH_CANNOT_ATTACH_TO_DESKTOP = unchecked((int)0x80040003);
    public const int E_LAUNCH_NO_INTEROP = unchecked((int)0x80040005);
    public const int E_LAUNCH_DEBUGGING_NOT_POSSIBLE = unchecked((int)0x80040006);
    public const int E_LAUNCH_KERNEL_DEBUGGER_ENABLED = unchecked((int)0x80040007);
    public const int E_LAUNCH_KERNEL_DEBUGGER_PRESENT = unchecked((int)0x80040008);
    public const int E_INTEROP_NOT_SUPPORTED = unchecked((int)0x80040009);
    public const int E_TOO_MANY_PROCESSES = unchecked((int)0x8004000A);
    public const int E_MSHTML_SCRIPT_DEBUGGING_DISABLED = unchecked((int)0x8004000B);
    public const int E_SCRIPT_PDM_NOT_REGISTERED = unchecked((int)0x8004000C);
    public const int E_DE_CLR_DBG_SERVICES_NOT_INSTALLED = unchecked((int)0x8004000D);
    public const int E_ATTACH_NO_CLR_PROGRAMS = unchecked((int)0x8004000E);
    public const int E_REMOTE_SERVER_CLOSED = unchecked((int)0x80040010);
    public const int E_CLR_NOT_SUPPORTED = unchecked((int)0x80040016);
    public const int E_64BIT_CLR_NOT_SUPPORTED = unchecked((int)0x80040017);
    public const int E_CANNOT_MIX_MINDUMP_DEBUGGING = unchecked((int)0x80040018);
    public const int E_DEBUG_ENGINE_NOT_REGISTERED = unchecked((int)0x80040019);
    public const int E_LAUNCH_SXS_ERROR = unchecked((int)0x8004001A);
    public const int E_REMOTE_SERVER_DOES_NOT_EXIST = unchecked((int)0x80040020);
    public const int E_REMOTE_SERVER_ACCESS_DENIED = unchecked((int)0x80040021);
    public const int E_REMOTE_SERVER_MACHINE_DOES_NOT_EXIST = unchecked((int)0x80040022);
    public const int E_DEBUGGER_NOT_REGISTERED_PROPERLY = unchecked((int)0x80040023);
    public const int E_FORCE_GUEST_MODE_ENABLED = unchecked((int)0x80040024);
    public const int E_GET_IWAM_USER_FAILURE = unchecked((int)0x80040025);
    public const int E_REMOTE_SERVER_INVALID_NAME = unchecked((int)0x80040026);
    public const int E_REMOTE_SERVER_MACHINE_NO_DEFAULT = unchecked((int)0x80040027);
    public const int E_AUTO_LAUNCH_EXEC_FAILURE = unchecked((int)0x80040028);
    public const int E_SERVICE_ACCESS_DENIED = unchecked((int)0x80040029);
    public const int E_SERVICE_ACCESS_DENIED_ON_CALLBACK = unchecked((int)0x8004002A);
    public const int E_REMOTE_COMPONENTS_NOT_REGISTERED = unchecked((int)0x8004002B);
    public const int E_DCOM_ACCESS_DENIED = unchecked((int)0x8004002C);
    public const int E_SHARE_LEVEL_ACCESS_CONTROL_ENABLED = unchecked((int)0x8004002D);
    public const int E_WORKGROUP_REMOTE_LOGON_FAILURE = unchecked((int)0x8004002E);
    public const int E_WINAUTH_CONNECT_NOT_SUPPORTED = unchecked((int)0x8004002F);
    public const int E_EVALUATE_BUSY_WITH_EVALUATION = unchecked((int)0x80040030);
    public const int E_EVALUATE_TIMEOUT = unchecked((int)0x80040031);
    public const int E_INTEROP_NOT_SUPPORTED_FOR_THIS_CLR = unchecked((int)0x80040032);
    public const int E_CLR_INCOMPATIBLE_PROTOCOL = unchecked((int)0x80040033);
    public const int E_CLR_CANNOT_DEBUG_FIBER_PROCESS = unchecked((int)0x80040034);
    public const int E_PROCESS_OBJECT_ACCESS_DENIED = unchecked((int)0x80040035);
    public const int E_PROCESS_TOKEN_ACCESS_DENIED = unchecked((int)0x80040036);
    public const int E_PROCESS_TOKEN_ACCESS_DENIED_NO_TS = unchecked((int)0x80040037);
    public const int E_OPERATION_REQUIRES_ELEVATION = unchecked((int)0x80040038);
    public const int E_ATTACH_REQUIRES_ELEVATION = unchecked((int)0x80040039);
    public const int E_MEMORY_NOTSUPPORTED = unchecked((int)0x80040040);
    public const int E_DISASM_NOTSUPPORTED = unchecked((int)0x80040041);
    public const int E_DISASM_BADADDRESS = unchecked((int)0x80040042);
    public const int E_DISASM_NOTAVAILABLE = unchecked((int)0x80040043);
    public const int E_BP_DELETED = unchecked((int)0x80040060);
    public const int E_PROCESS_DESTROYED = unchecked((int)0x80040070);
    public const int E_PROCESS_DEBUGGER_IS_DEBUGGEE = unchecked((int)0x80040071);
    public const int E_TERMINATE_FORBIDDEN = unchecked((int)0x80040072);
    public const int E_THREAD_DESTROYED = unchecked((int)0x80040075);
    public const int E_PORTSUPPLIER_NO_PORT = unchecked((int)0x80040080);
    public const int E_PORT_NO_REQUEST = unchecked((int)0x80040090);
    public const int E_COMPARE_CANNOT_COMPARE = unchecked((int)0x800400A0);
    public const int E_JIT_INVALID_PID = unchecked((int)0x800400B1);
    public const int E_JIT_VSJITDEBUGGER_NOT_REGISTERED = unchecked((int)0x800400B3);
    public const int E_JIT_APPID_NOT_REGISTERED = unchecked((int)0x800400B4);
    public const int E_SESSION_TERMINATE_DETACH_FAILED = unchecked((int)0x800400C2);
    public const int E_SESSION_TERMINATE_FAILED = unchecked((int)0x800400C3);
    public const int E_DETACH_NO_PROXY = unchecked((int)0x800400D0);
    public const int E_DETACH_TS_UNSUPPORTED = unchecked((int)0x800400E0);
    public const int E_DETACH_IMPERSONATE_FAILURE = unchecked((int)0x800400F0);
    public const int E_CANNOT_SET_NEXT_STATEMENT_ON_NONLEAF_FRAME = unchecked((int)0x80040100);
    public const int E_TARGET_FILE_MISMATCH = unchecked((int)0x80040101);
    public const int E_IMAGE_NOT_LOADED = unchecked((int)0x80040102);
    public const int E_FIBER_NOT_SUPPORTED = unchecked((int)0x80040103);
    public const int E_CANNOT_SETIP_TO_DIFFERENT_FUNCTION = unchecked((int)0x80040104);
    public const int E_CANNOT_SET_NEXT_STATEMENT_ON_EXCEPTION = unchecked((int)0x80040105);
    public const int E_ENC_SETIP_REQUIRES_CONTINUE = unchecked((int)0x80040107);
    public const int E_CANNOT_SET_NEXT_STATEMENT_INTO_FINALLY = unchecked((int)0x80040108);
    public const int E_CANNOT_SET_NEXT_STATEMENT_OUT_OF_FINALLY = unchecked((int)0x80040109);
    public const int E_CANNOT_SET_NEXT_STATEMENT_INTO_CATCH = unchecked((int)0x8004010A);
    public const int E_CANNOT_SET_NEXT_STATEMENT_GENERAL = unchecked((int)0x8004010B);
    public const int E_CANNOT_SET_NEXT_STATEMENT_INTO_OR_OUT_OF_FILTER = unchecked((int)0x8004010C);
    public const int E_ASYNCBREAK_NO_PROGRAMS = unchecked((int)0x80040110);
    public const int E_ASYNCBREAK_DEBUGGEE_NOT_INITIALIZED = unchecked((int)0x80040111);
    public const int E_WEBDBG_DEBUG_VERB_BLOCKED = unchecked((int)0x80040121);
    public const int E_ASP_USER_ACCESS_DENIED = unchecked((int)0x80040125);
    public const int E_AUTO_ATTACH_NOT_REGISTERED = unchecked((int)0x80040126);
    public const int E_AUTO_ATTACH_DCOM_ERROR = unchecked((int)0x80040127);
    public const int E_AUTO_ATTACH_NOT_SUPPORTED = unchecked((int)0x80040128);
    public const int E_AUTO_ATTACH_CLASSNOTREG = unchecked((int)0x80040129);
    public const int E_CANNOT_CONTINUE_DURING_PENDING_EXPR_EVAL = unchecked((int)0x80040130);
    public const int E_REMOTE_REDIRECTION_UNSUPPORTED = unchecked((int)0x80040135);
    public const int E_INVALID_WORKING_DIRECTORY = unchecked((int)0x80040136);
    public const int E_LAUNCH_FAILED_WITH_ELEVATION = unchecked((int)0x80040137);
    public const int E_LAUNCH_ELEVATION_REQUIRED = unchecked((int)0x80040138);
    public const int E_CANNOT_FIND_INTERNET_EXPLORER = unchecked((int)0x80040139);
    public const int E_EXCEPTION_CANNOT_BE_INTERCEPTED = unchecked((int)0x80040140);
    public const int E_EXCEPTION_CANNOT_UNWIND_ABOVE_CALLBACK = unchecked((int)0x80040141);
    public const int E_INTERCEPT_CURRENT_EXCEPTION_NOT_SUPPORTED = unchecked((int)0x80040142);
    public const int E_INTERCEPT_CANNOT_UNWIND_LASTCHANCE_INTEROP = unchecked((int)0x80040143);
    public const int E_JMC_CANNOT_SET_STATUS = unchecked((int)0x80040145);
    public const int E_DESTROYED = unchecked((int)0x80040201);
    public const int E_REMOTE_NOMSVCMON = unchecked((int)0x80040202);
    public const int E_REMOTE_BADIPADDRESS = unchecked((int)0x80040203);
    public const int E_REMOTE_MACHINEDOWN = unchecked((int)0x80040204);
    public const int E_REMOTE_MACHINEUNSPECIFIED = unchecked((int)0x80040205);
    public const int E_CRASHDUMP_ACTIVE = unchecked((int)0x80040206);
    public const int E_ALL_THREADS_SUSPENDED = unchecked((int)0x80040207);
    public const int E_LOAD_DLL_TL = unchecked((int)0x80040208);
    public const int E_LOAD_DLL_SH = unchecked((int)0x80040209);
    public const int E_LOAD_DLL_EM = unchecked((int)0x8004020A);
    public const int E_LOAD_DLL_EE = unchecked((int)0x8004020B);
    public const int E_LOAD_DLL_DM = unchecked((int)0x8004020C);
    public const int E_LOAD_DLL_MD = unchecked((int)0x8004020D);
    public const int E_IOREDIR_BADFILE = unchecked((int)0x8004020E);
    public const int E_IOREDIR_BADSYNTAX = unchecked((int)0x8004020F);
    public const int E_REMOTE_BADVERSION = unchecked((int)0x80040210);
    public const int E_CRASHDUMP_UNSUPPORTED = unchecked((int)0x80040211);
    public const int E_REMOTE_BAD_CLR_VERSION = unchecked((int)0x80040212);
    public const int E_UNSUPPORTED_BINARY = unchecked((int)0x80040215);
    public const int E_DEBUGGEE_BLOCKED = unchecked((int)0x80040216);
    public const int E_REMOTE_NOUSERMSVCMON = unchecked((int)0x80040217);
    public const int E_STEP_WIN9xSYSCODE = unchecked((int)0x80040218);
    public const int E_INTEROP_ORPC_INIT = unchecked((int)0x80040219);
    public const int E_CANNOT_DEBUG_WIN32 = unchecked((int)0x8004021B);
    public const int E_CANNOT_DEBUG_WIN64 = unchecked((int)0x8004021C);
    public const int E_MINIDUMP_READ_WIN9X = unchecked((int)0x8004021D);
    public const int E_CROSS_TSSESSION_ATTACH = unchecked((int)0x8004021E);
    public const int E_STEP_BP_SET_FAILED = unchecked((int)0x8004021F);
    public const int E_LOAD_DLL_TL_INCORRECT_VERSION = unchecked((int)0x80040220);
    public const int E_LOAD_DLL_DM_INCORRECT_VERSION = unchecked((int)0x80040221);
    public const int E_REMOTE_NOMSVCMON_PIPE = unchecked((int)0x80040222);
    public const int E_LOAD_DLL_DIA = unchecked((int)0x80040223);
    public const int E_DUMP_CORRUPTED = unchecked((int)0x80040224);
    public const int E_INTEROP_WIN64 = unchecked((int)0x80040225);
    public const int E_CRASHDUMP_DEPRECATED = unchecked((int)0x80040227);
    public const int E_DEVICEBITS_NOT_SIGNED = unchecked((int)0x80040401);
    public const int E_ATTACH_NOT_ENABLED = unchecked((int)0x80040402);
    public const int E_REMOTE_DISCONNECT = unchecked((int)0x80040403);
    public const int E_BREAK_ALL_FAILED = unchecked((int)0x80040404);
    public const int E_DEVICE_ACCESS_DENIED_SELECT_YES = unchecked((int)0x80040405);
    public const int E_DEVICE_ACCESS_DENIED = unchecked((int)0x80040406);
    public const int E_DEVICE_CONNRESET = unchecked((int)0x80040407);
    public const int E_BAD_NETCF_VERSION = unchecked((int)0x80040408);
    public const int E_REFERENCE_NOT_VALID = unchecked((int)0x80040501);
    public const int E_PROPERTY_NOT_VALID = unchecked((int)0x80040511);
    public const int E_SETVALUE_VALUE_CANNOT_BE_SET = unchecked((int)0x80040521);
    public const int E_SETVALUE_VALUE_IS_READONLY = unchecked((int)0x80040522);
    public const int E_SETVALUEASREFERENCE_NOTSUPPORTED = unchecked((int)0x80040523);
    public const int E_CANNOT_GET_UNMANAGED_MEMORY_CONTEXT = unchecked((int)0x80040561);
    public const int E_GETREFERENCE_NO_REFERENCE = unchecked((int)0x80040581);
    public const int E_CODE_CONTEXT_OUT_OF_SCOPE = unchecked((int)0x800405A1);
    public const int E_INVALID_SESSIONID = unchecked((int)0x800405A2);
    public const int E_SERVER_UNAVAILABLE_ON_CALLBACK = unchecked((int)0x800405A3);
    public const int E_ACCESS_DENIED_ON_CALLBACK = unchecked((int)0x800405A4);
    public const int E_UNKNOWN_AUTHN_SERVICE_ON_CALLBACK = unchecked((int)0x800405A5);
    public const int E_NO_SESSION_AVAILABLE = unchecked((int)0x800405A6);
    public const int E_CLIENT_NOT_LOGGED_ON = unchecked((int)0x800405A7);
    public const int E_OTHER_USERS_SESSION = unchecked((int)0x800405A8);
    public const int E_USER_LEVEL_ACCESS_CONTROL_REQUIRED = unchecked((int)0x800405A9);
    public const int E_SCRIPT_CLR_EE_DISABLED = unchecked((int)0x800405B0);
    public const int E_HTTP_SERVERERROR = unchecked((int)0x80040700);
    public const int E_HTTP_UNAUTHORIZED = unchecked((int)0x80040701);
    public const int E_HTTP_SENDREQUEST_FAILED = unchecked((int)0x80040702);
    public const int E_HTTP_FORBIDDEN = unchecked((int)0x80040703);
    public const int E_HTTP_NOT_SUPPORTED = unchecked((int)0x80040704);
    public const int E_HTTP_NO_CONTENT = unchecked((int)0x80040705);
    public const int E_HTTP_NOT_FOUND = unchecked((int)0x80040706);
    public const int E_HTTP_BAD_REQUEST = unchecked((int)0x80040707);
    public const int E_HTTP_ACCESS_DENIED = unchecked((int)0x80040708);
    public const int E_HTTP_CONNECT_FAILED = unchecked((int)0x80040709);
    public const int E_HTTP_EXCEPTION = unchecked((int)0x8004070A);
    public const int E_HTTP_TIMEOUT = unchecked((int)0x8004070B);
    public const int E_64BIT_COMPONENTS_NOT_INSTALLED = unchecked((int)0x80040750);
    public const int E_UNMARSHAL_SERVER_FAILED = unchecked((int)0x80040751);
    public const int E_UNMARSHAL_CALLBACK_FAILED = unchecked((int)0x80040752);
    public const int E_RPC_REQUIRES_AUTHENTICATION = unchecked((int)0x80040755);
    public const int E_LOGON_FAILURE_ON_CALLBACK = unchecked((int)0x80040756);
    public const int E_REMOTE_SERVER_UNAVAILABLE = unchecked((int)0x80040757);
    public const int E_FIREWALL_USER_CANCELED = unchecked((int)0x80040758);
    public const int E_REMOTE_CREDENTIALS_PROHIBITED = unchecked((int)0x80040759);
    public const int E_FIREWALL_NO_EXCEPTIONS = unchecked((int)0x8004075A);
    public const int E_FIREWALL_CANNOT_OPEN_APPLICATION = unchecked((int)0x8004075B);
    public const int E_FIREWALL_CANNOT_OPEN_PORT = unchecked((int)0x8004075C);
    public const int E_FIREWALL_CANNOT_OPEN_FILE_SHARING = unchecked((int)0x8004075D);
    public const int E_REMOTE_DEBUGGING_UNSUPPORTED = unchecked((int)0x8004075E);
    public const int E_REMOTE_BAD_MSDBG2 = unchecked((int)0x8004075F);
    public const int E_ATTACH_USER_CANCELED = unchecked((int)0x80040760);
    public const int E_FUNCTION_NOT_JITTED = unchecked((int)0x80040800);
    public const int E_NO_CODE_CONTEXT = unchecked((int)0x80040801);
    public const int E_BAD_CLR_DIASYMREADER = unchecked((int)0x80040802);
    public const int E_CLR_SHIM_ERROR = unchecked((int)0x80040803);
    public const int E_AUTOATTACH_ACCESS_DENIED = unchecked((int)0x80040900);
    public const int E_AUTOATTACH_WEBSERVER_NOT_FOUND = unchecked((int)0x80040901);
    public const int E_DBGEXTENSION_NOT_FOUND = unchecked((int)0x80040910);
    public const int E_DBGEXTENSION_FUNCTION_NOT_FOUND = unchecked((int)0x80040911);
    public const int E_DBGEXTENSION_FAULTED = unchecked((int)0x80040912);
    public const int E_DBGEXTENSION_RESULT_INVALID = unchecked((int)0x80040913);
    public const int E_PROGRAM_IN_RUNMODE = unchecked((int)0x80040914);
    public const int E_CAUSALITY_NO_SERVER_RESPONSE = unchecked((int)0x80040920);
    public const int E_CAUSALITY_REMOTE_NOT_REGISTERED = unchecked((int)0x80040921);
    public const int E_CAUSALITY_BREAKPOINT_NOT_HIT = unchecked((int)0x80040922);
    public const int E_CAUSALITY_BREAKPOINT_BIND_ERROR = unchecked((int)0x80040923);
    public const int E_CAUSALITY_PROJECT_DISABLED = unchecked((int)0x80040924);
    public const int E_NO_ATTACH_WHILE_DDD = unchecked((int)0x80040A00);
    public const int E_SQLLE_ACCESSDENIED = unchecked((int)0x80040A01);
    public const int E_SQL_SP_ENABLE_PERMISSION_DENIED = unchecked((int)0x80040A02);
    public const int E_SQL_DEBUGGING_NOT_ENABLED_ON_SERVER = unchecked((int)0x80040A03);
    public const int E_SQL_CANT_FIND_SSDEBUGPS_ON_CLIENT = unchecked((int)0x80040A04);
    public const int E_SQL_EXECUTED_BUT_NOT_DEBUGGED = unchecked((int)0x80040A05);
    public const int E_SQL_VDT_INIT_RETURNED_SQL_ERROR = unchecked((int)0x80040A06);
    public const int E_ATTACH_FAILED_ABORT_SILENTLY = unchecked((int)0x80040A07);
    public const int E_SQL_REGISTER_FAILED = unchecked((int)0x80040A08);
    public const int E_DE_NOT_SUPPORTED_PRE_8_0 = unchecked((int)0x80040B00);
    public const int E_PROGRAM_DESTROY_PENDING = unchecked((int)0x80040B01);
    public const int E_MANAGED_FEATURE_NOTSUPPORTED = unchecked((int)0x80040BAD);
  }
}
