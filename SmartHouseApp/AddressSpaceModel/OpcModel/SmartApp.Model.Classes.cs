/* ========================================================================
 * Copyright (c) 2005-2016 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;

namespace SmartApp.Model
{
    #region Object Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Objects
    {
        /// <summary>
        /// The identifier for the User_Coordinates Object.
        /// </summary>
        public const uint User_Coordinates = 4;

        /// <summary>
        /// The identifier for the Room_Devices Object.
        /// </summary>
        public const uint Room_Devices = 17;
    }
    #endregion

    #region ObjectType Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypes
    {
        /// <summary>
        /// The identifier for the User ObjectType.
        /// </summary>
        public const uint User = 1;

        /// <summary>
        /// The identifier for the Location ObjectType.
        /// </summary>
        public const uint Location = 5;

        /// <summary>
        /// The identifier for the Room ObjectType.
        /// </summary>
        public const uint Room = 14;

        /// <summary>
        /// The identifier for the Device ObjectType.
        /// </summary>
        public const uint Device = 22;
    }
    #endregion

    #region Variable Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <summary>
        /// The identifier for the User_Id Variable.
        /// </summary>
        public const uint User_Id = 2;

        /// <summary>
        /// The identifier for the User_Name Variable.
        /// </summary>
        public const uint User_Name = 3;

        /// <summary>
        /// The identifier for the User_Coordinates_CoordinatesX Variable.
        /// </summary>
        public const uint User_Coordinates_CoordinatesX = 6;

        /// <summary>
        /// The identifier for the User_Coordinates_CoordinatesY Variable.
        /// </summary>
        public const uint User_Coordinates_CoordinatesY = 7;

        /// <summary>
        /// The identifier for the User_FirstName Variable.
        /// </summary>
        public const uint User_FirstName = 8;

        /// <summary>
        /// The identifier for the User_LastName Variable.
        /// </summary>
        public const uint User_LastName = 9;

        /// <summary>
        /// The identifier for the User_Email Variable.
        /// </summary>
        public const uint User_Email = 10;

        /// <summary>
        /// The identifier for the User_Password Variable.
        /// </summary>
        public const uint User_Password = 11;

        /// <summary>
        /// The identifier for the Location_CoordinatesX Variable.
        /// </summary>
        public const uint Location_CoordinatesX = 12;

        /// <summary>
        /// The identifier for the Location_CoordinatesY Variable.
        /// </summary>
        public const uint Location_CoordinatesY = 13;

        /// <summary>
        /// The identifier for the Room_Id Variable.
        /// </summary>
        public const uint Room_Id = 15;

        /// <summary>
        /// The identifier for the Room_Name Variable.
        /// </summary>
        public const uint Room_Name = 16;

        /// <summary>
        /// The identifier for the Room_Devices_Id Variable.
        /// </summary>
        public const uint Room_Devices_Id = 18;

        /// <summary>
        /// The identifier for the Room_Devices_Name Variable.
        /// </summary>
        public const uint Room_Devices_Name = 19;

        /// <summary>
        /// The identifier for the Room_Devices_Enabled Variable.
        /// </summary>
        public const uint Room_Devices_Enabled = 20;

        /// <summary>
        /// The identifier for the Room_Devices_LastState Variable.
        /// </summary>
        public const uint Room_Devices_LastState = 21;

        /// <summary>
        /// The identifier for the Device_Id Variable.
        /// </summary>
        public const uint Device_Id = 23;

        /// <summary>
        /// The identifier for the Device_Name Variable.
        /// </summary>
        public const uint Device_Name = 24;

        /// <summary>
        /// The identifier for the Device_Enabled Variable.
        /// </summary>
        public const uint Device_Enabled = 25;

        /// <summary>
        /// The identifier for the Device_LastState Variable.
        /// </summary>
        public const uint Device_LastState = 26;
    }
    #endregion

    #region Object Node Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectIds
    {
        /// <summary>
        /// The identifier for the User_Coordinates Object.
        /// </summary>
        public static readonly ExpandedNodeId User_Coordinates = new ExpandedNodeId(SmartApp.Model.Objects.User_Coordinates, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the Room_Devices Object.
        /// </summary>
        public static readonly ExpandedNodeId Room_Devices = new ExpandedNodeId(SmartApp.Model.Objects.Room_Devices, SmartApp.Model.Namespaces.SmartApp_Model);
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypeIds
    {
        /// <summary>
        /// The identifier for the User ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId User = new ExpandedNodeId(SmartApp.Model.ObjectTypes.User, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the Location ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId Location = new ExpandedNodeId(SmartApp.Model.ObjectTypes.Location, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the Room ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId Room = new ExpandedNodeId(SmartApp.Model.ObjectTypes.Room, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the Device ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId Device = new ExpandedNodeId(SmartApp.Model.ObjectTypes.Device, SmartApp.Model.Namespaces.SmartApp_Model);
    }
    #endregion

    #region Variable Node Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <summary>
        /// The identifier for the User_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId User_Id = new ExpandedNodeId(SmartApp.Model.Variables.User_Id, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the User_Name Variable.
        /// </summary>
        public static readonly ExpandedNodeId User_Name = new ExpandedNodeId(SmartApp.Model.Variables.User_Name, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the User_Coordinates_CoordinatesX Variable.
        /// </summary>
        public static readonly ExpandedNodeId User_Coordinates_CoordinatesX = new ExpandedNodeId(SmartApp.Model.Variables.User_Coordinates_CoordinatesX, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the User_Coordinates_CoordinatesY Variable.
        /// </summary>
        public static readonly ExpandedNodeId User_Coordinates_CoordinatesY = new ExpandedNodeId(SmartApp.Model.Variables.User_Coordinates_CoordinatesY, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the User_FirstName Variable.
        /// </summary>
        public static readonly ExpandedNodeId User_FirstName = new ExpandedNodeId(SmartApp.Model.Variables.User_FirstName, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the User_LastName Variable.
        /// </summary>
        public static readonly ExpandedNodeId User_LastName = new ExpandedNodeId(SmartApp.Model.Variables.User_LastName, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the User_Email Variable.
        /// </summary>
        public static readonly ExpandedNodeId User_Email = new ExpandedNodeId(SmartApp.Model.Variables.User_Email, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the User_Password Variable.
        /// </summary>
        public static readonly ExpandedNodeId User_Password = new ExpandedNodeId(SmartApp.Model.Variables.User_Password, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the Location_CoordinatesX Variable.
        /// </summary>
        public static readonly ExpandedNodeId Location_CoordinatesX = new ExpandedNodeId(SmartApp.Model.Variables.Location_CoordinatesX, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the Location_CoordinatesY Variable.
        /// </summary>
        public static readonly ExpandedNodeId Location_CoordinatesY = new ExpandedNodeId(SmartApp.Model.Variables.Location_CoordinatesY, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the Room_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId Room_Id = new ExpandedNodeId(SmartApp.Model.Variables.Room_Id, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the Room_Name Variable.
        /// </summary>
        public static readonly ExpandedNodeId Room_Name = new ExpandedNodeId(SmartApp.Model.Variables.Room_Name, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the Room_Devices_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId Room_Devices_Id = new ExpandedNodeId(SmartApp.Model.Variables.Room_Devices_Id, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the Room_Devices_Name Variable.
        /// </summary>
        public static readonly ExpandedNodeId Room_Devices_Name = new ExpandedNodeId(SmartApp.Model.Variables.Room_Devices_Name, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the Room_Devices_Enabled Variable.
        /// </summary>
        public static readonly ExpandedNodeId Room_Devices_Enabled = new ExpandedNodeId(SmartApp.Model.Variables.Room_Devices_Enabled, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the Room_Devices_LastState Variable.
        /// </summary>
        public static readonly ExpandedNodeId Room_Devices_LastState = new ExpandedNodeId(SmartApp.Model.Variables.Room_Devices_LastState, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the Device_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId Device_Id = new ExpandedNodeId(SmartApp.Model.Variables.Device_Id, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the Device_Name Variable.
        /// </summary>
        public static readonly ExpandedNodeId Device_Name = new ExpandedNodeId(SmartApp.Model.Variables.Device_Name, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the Device_Enabled Variable.
        /// </summary>
        public static readonly ExpandedNodeId Device_Enabled = new ExpandedNodeId(SmartApp.Model.Variables.Device_Enabled, SmartApp.Model.Namespaces.SmartApp_Model);

        /// <summary>
        /// The identifier for the Device_LastState Variable.
        /// </summary>
        public static readonly ExpandedNodeId Device_LastState = new ExpandedNodeId(SmartApp.Model.Variables.Device_LastState, SmartApp.Model.Namespaces.SmartApp_Model);
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model Design.
    /// </summary>
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the Coordinates component.
        /// </summary>
        public const string Coordinates = "Coordinates";

        /// <summary>
        /// The BrowseName for the CoordinatesX component.
        /// </summary>
        public const string CoordinatesX = "CoordinatesX";

        /// <summary>
        /// The BrowseName for the CoordinatesY component.
        /// </summary>
        public const string CoordinatesY = "CoordinatesY";

        /// <summary>
        /// The BrowseName for the Device component.
        /// </summary>
        public const string Device = "Device";

        /// <summary>
        /// The BrowseName for the Devices component.
        /// </summary>
        public const string Devices = "Devices";

        /// <summary>
        /// The BrowseName for the Email component.
        /// </summary>
        public const string Email = "Email";

        /// <summary>
        /// The BrowseName for the Enabled component.
        /// </summary>
        public const string Enabled = "Enabled";

        /// <summary>
        /// The BrowseName for the FirstName component.
        /// </summary>
        public const string FirstName = "FirstName";

        /// <summary>
        /// The BrowseName for the Id component.
        /// </summary>
        public const string Id = "Id";

        /// <summary>
        /// The BrowseName for the LastName component.
        /// </summary>
        public const string LastName = "LastName";

        /// <summary>
        /// The BrowseName for the LastState component.
        /// </summary>
        public const string LastState = "LastState";

        /// <summary>
        /// The BrowseName for the Location component.
        /// </summary>
        public const string Location = "Location";

        /// <summary>
        /// The BrowseName for the Name component.
        /// </summary>
        public const string Name = "Name";

        /// <summary>
        /// The BrowseName for the Password component.
        /// </summary>
        public const string Password = "Password";

        /// <summary>
        /// The BrowseName for the Room component.
        /// </summary>
        public const string Room = "Room";

        /// <summary>
        /// The BrowseName for the User component.
        /// </summary>
        public const string User = "User";
    }
    #endregion

    #region Namespace Declarations
    /// <summary>
    /// Defines constants for all namespaces referenced by the model design.
    /// </summary>
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the SmartApp_Model namespace (.NET code namespace is 'SmartApp.Model').
        /// </summary>
        public const string SmartApp_Model = "http://screensaver.com/TPUM/SmartHouseApp/";

        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";
    }
    #endregion

    #region UserState Class
    #if (!OPCUA_EXCLUDE_UserState)
    /// <summary>
    /// Stores an instance of the User ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class UserState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public UserState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(SmartApp.Model.ObjectTypes.User, SmartApp.Model.Namespaces.SmartApp_Model, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACoAAABodHRwOi8vc2NyZWVuc2F2ZXIuY29tL1RQVU0vU21hcnRIb3VzZUFwcC//////BGCAAAEA" +
           "AAABAAwAAABVc2VySW5zdGFuY2UBAQEAAQEBAP////8HAAAAFWCJCgIAAAABAAIAAABJZAEBAgAALwA/" +
           "AgAAAAAb/////wEB/////wAAAAAVYIkKAgAAAAEABAAAAE5hbWUBAQMAAC8APwMAAAAADP////8BAf//" +
           "//8AAAAABGCACgEAAAABAAsAAABDb29yZGluYXRlcwEBBAAALwEBBQAEAAAA/////wIAAAAVYIkKAgAA" +
           "AAEADAAAAENvb3JkaW5hdGVzWAEBBgAALwA/BgAAAAAL/////wEB/////wAAAAAVYIkKAgAAAAEADAAA" +
           "AENvb3JkaW5hdGVzWQEBBwAALwA/BwAAAAAL/////wEB/////wAAAAAVYIkKAgAAAAEACQAAAEZpcnN0" +
           "TmFtZQEBCAAALwA/CAAAAAAM/////wEB/////wAAAAAVYIkKAgAAAAEACAAAAExhc3ROYW1lAQEJAAAv" +
           "AD8JAAAAAAz/////AQH/////AAAAABVgiQoCAAAAAQAFAAAARW1haWwBAQoAAC8APwoAAAAADP////8B" +
           "Af////8AAAAAFWCJCgIAAAABAAgAAABQYXNzd29yZAEBCwAALwA/CwAAAAAM/////wEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Id Variable.
        /// </summary>
        public BaseDataVariableState Id
        {
            get
            {
                return m_id;
            }

            set
            {
                if (!Object.ReferenceEquals(m_id, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_id = value;
            }
        }

        /// <summary>
        /// A description for the Name Variable.
        /// </summary>
        public BaseDataVariableState<string> Name
        {
            get
            {
                return m_name;
            }

            set
            {
                if (!Object.ReferenceEquals(m_name, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_name = value;
            }
        }

        /// <summary>
        /// A description for the Coordinates Object.
        /// </summary>
        public LocationState Coordinates
        {
            get
            {
                return m_coordinates;
            }

            set
            {
                if (!Object.ReferenceEquals(m_coordinates, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_coordinates = value;
            }
        }

        /// <summary>
        /// A description for the FirstName Variable.
        /// </summary>
        public BaseDataVariableState<string> FirstName
        {
            get
            {
                return m_firstName;
            }

            set
            {
                if (!Object.ReferenceEquals(m_firstName, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_firstName = value;
            }
        }

        /// <summary>
        /// A description for the LastName Variable.
        /// </summary>
        public BaseDataVariableState<string> LastName
        {
            get
            {
                return m_lastName;
            }

            set
            {
                if (!Object.ReferenceEquals(m_lastName, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_lastName = value;
            }
        }

        /// <summary>
        /// A description for the Email Variable.
        /// </summary>
        public BaseDataVariableState<string> Email
        {
            get
            {
                return m_email;
            }

            set
            {
                if (!Object.ReferenceEquals(m_email, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_email = value;
            }
        }

        /// <summary>
        /// A description for the Password Variable.
        /// </summary>
        public BaseDataVariableState<string> Password
        {
            get
            {
                return m_password;
            }

            set
            {
                if (!Object.ReferenceEquals(m_password, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_password = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_id != null)
            {
                children.Add(m_id);
            }

            if (m_name != null)
            {
                children.Add(m_name);
            }

            if (m_coordinates != null)
            {
                children.Add(m_coordinates);
            }

            if (m_firstName != null)
            {
                children.Add(m_firstName);
            }

            if (m_lastName != null)
            {
                children.Add(m_lastName);
            }

            if (m_email != null)
            {
                children.Add(m_email);
            }

            if (m_password != null)
            {
                children.Add(m_password);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case SmartApp.Model.BrowseNames.Id:
                {
                    if (createOrReplace)
                    {
                        if (Id == null)
                        {
                            if (replacement == null)
                            {
                                Id = new BaseDataVariableState(this);
                            }
                            else
                            {
                                Id = (BaseDataVariableState)replacement;
                            }
                        }
                    }

                    instance = Id;
                    break;
                }

                case SmartApp.Model.BrowseNames.Name:
                {
                    if (createOrReplace)
                    {
                        if (Name == null)
                        {
                            if (replacement == null)
                            {
                                Name = new BaseDataVariableState<string>(this);
                            }
                            else
                            {
                                Name = (BaseDataVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = Name;
                    break;
                }

                case SmartApp.Model.BrowseNames.Coordinates:
                {
                    if (createOrReplace)
                    {
                        if (Coordinates == null)
                        {
                            if (replacement == null)
                            {
                                Coordinates = new LocationState(this);
                            }
                            else
                            {
                                Coordinates = (LocationState)replacement;
                            }
                        }
                    }

                    instance = Coordinates;
                    break;
                }

                case SmartApp.Model.BrowseNames.FirstName:
                {
                    if (createOrReplace)
                    {
                        if (FirstName == null)
                        {
                            if (replacement == null)
                            {
                                FirstName = new BaseDataVariableState<string>(this);
                            }
                            else
                            {
                                FirstName = (BaseDataVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = FirstName;
                    break;
                }

                case SmartApp.Model.BrowseNames.LastName:
                {
                    if (createOrReplace)
                    {
                        if (LastName == null)
                        {
                            if (replacement == null)
                            {
                                LastName = new BaseDataVariableState<string>(this);
                            }
                            else
                            {
                                LastName = (BaseDataVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = LastName;
                    break;
                }

                case SmartApp.Model.BrowseNames.Email:
                {
                    if (createOrReplace)
                    {
                        if (Email == null)
                        {
                            if (replacement == null)
                            {
                                Email = new BaseDataVariableState<string>(this);
                            }
                            else
                            {
                                Email = (BaseDataVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = Email;
                    break;
                }

                case SmartApp.Model.BrowseNames.Password:
                {
                    if (createOrReplace)
                    {
                        if (Password == null)
                        {
                            if (replacement == null)
                            {
                                Password = new BaseDataVariableState<string>(this);
                            }
                            else
                            {
                                Password = (BaseDataVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = Password;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseDataVariableState m_id;
        private BaseDataVariableState<string> m_name;
        private LocationState m_coordinates;
        private BaseDataVariableState<string> m_firstName;
        private BaseDataVariableState<string> m_lastName;
        private BaseDataVariableState<string> m_email;
        private BaseDataVariableState<string> m_password;
        #endregion
    }
    #endif
    #endregion

    #region LocationState Class
    #if (!OPCUA_EXCLUDE_LocationState)
    /// <summary>
    /// Stores an instance of the Location ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class LocationState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public LocationState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(SmartApp.Model.ObjectTypes.Location, SmartApp.Model.Namespaces.SmartApp_Model, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACoAAABodHRwOi8vc2NyZWVuc2F2ZXIuY29tL1RQVU0vU21hcnRIb3VzZUFwcC//////BGCAAAEA" +
           "AAABABAAAABMb2NhdGlvbkluc3RhbmNlAQEFAAEBBQD/////AgAAABVgiQoCAAAAAQAMAAAAQ29vcmRp" +
           "bmF0ZXNYAQEMAAAvAD8MAAAAAAv/////AQH/////AAAAABVgiQoCAAAAAQAMAAAAQ29vcmRpbmF0ZXNZ" +
           "AQENAAAvAD8NAAAAAAv/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the CoordinatesX Variable.
        /// </summary>
        public BaseDataVariableState<double> CoordinatesX
        {
            get
            {
                return m_coordinatesX;
            }

            set
            {
                if (!Object.ReferenceEquals(m_coordinatesX, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_coordinatesX = value;
            }
        }

        /// <summary>
        /// A description for the CoordinatesY Variable.
        /// </summary>
        public BaseDataVariableState<double> CoordinatesY
        {
            get
            {
                return m_coordinatesY;
            }

            set
            {
                if (!Object.ReferenceEquals(m_coordinatesY, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_coordinatesY = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_coordinatesX != null)
            {
                children.Add(m_coordinatesX);
            }

            if (m_coordinatesY != null)
            {
                children.Add(m_coordinatesY);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case SmartApp.Model.BrowseNames.CoordinatesX:
                {
                    if (createOrReplace)
                    {
                        if (CoordinatesX == null)
                        {
                            if (replacement == null)
                            {
                                CoordinatesX = new BaseDataVariableState<double>(this);
                            }
                            else
                            {
                                CoordinatesX = (BaseDataVariableState<double>)replacement;
                            }
                        }
                    }

                    instance = CoordinatesX;
                    break;
                }

                case SmartApp.Model.BrowseNames.CoordinatesY:
                {
                    if (createOrReplace)
                    {
                        if (CoordinatesY == null)
                        {
                            if (replacement == null)
                            {
                                CoordinatesY = new BaseDataVariableState<double>(this);
                            }
                            else
                            {
                                CoordinatesY = (BaseDataVariableState<double>)replacement;
                            }
                        }
                    }

                    instance = CoordinatesY;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseDataVariableState<double> m_coordinatesX;
        private BaseDataVariableState<double> m_coordinatesY;
        #endregion
    }
    #endif
    #endregion

    #region RoomState Class
    #if (!OPCUA_EXCLUDE_RoomState)
    /// <summary>
    /// Stores an instance of the Room ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class RoomState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public RoomState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(SmartApp.Model.ObjectTypes.Room, SmartApp.Model.Namespaces.SmartApp_Model, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACoAAABodHRwOi8vc2NyZWVuc2F2ZXIuY29tL1RQVU0vU21hcnRIb3VzZUFwcC//////BGCAAAEA" +
           "AAABAAwAAABSb29tSW5zdGFuY2UBAQ4AAQEOAP////8DAAAAFWCJCgIAAAABAAIAAABJZAEBDwAALwA/" +
           "DwAAAAAb/////wEB/////wAAAAAVYIkKAgAAAAEABAAAAE5hbWUBARAAAC8APxAAAAAADP////8BAf//" +
           "//8AAAAABGCACgEAAAABAAcAAABEZXZpY2VzAQERAAAvAQEWABEAAAD/////BAAAABVgiQoCAAAAAQAC" +
           "AAAASWQBARIAAC8APxIAAAAAG/////8BAf////8AAAAAFWCJCgIAAAABAAQAAABOYW1lAQETAAAvAD8T" +
           "AAAAAAz/////AQH/////AAAAABVgiQoCAAAAAQAHAAAARW5hYmxlZAEBFAAALwA/FAAAAAAB/////wEB" +
           "/////wAAAAAVYIkKAgAAAAEACQAAAExhc3RTdGF0ZQEBFQAALwA/FQAAAAAB/////wEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Id Variable.
        /// </summary>
        public BaseDataVariableState Id
        {
            get
            {
                return m_id;
            }

            set
            {
                if (!Object.ReferenceEquals(m_id, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_id = value;
            }
        }

        /// <summary>
        /// A description for the Name Variable.
        /// </summary>
        public BaseDataVariableState<string> Name
        {
            get
            {
                return m_name;
            }

            set
            {
                if (!Object.ReferenceEquals(m_name, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_name = value;
            }
        }

        /// <summary>
        /// A description for the Devices Object.
        /// </summary>
        public DeviceState Devices
        {
            get
            {
                return m_devices;
            }

            set
            {
                if (!Object.ReferenceEquals(m_devices, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_devices = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_id != null)
            {
                children.Add(m_id);
            }

            if (m_name != null)
            {
                children.Add(m_name);
            }

            if (m_devices != null)
            {
                children.Add(m_devices);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case SmartApp.Model.BrowseNames.Id:
                {
                    if (createOrReplace)
                    {
                        if (Id == null)
                        {
                            if (replacement == null)
                            {
                                Id = new BaseDataVariableState(this);
                            }
                            else
                            {
                                Id = (BaseDataVariableState)replacement;
                            }
                        }
                    }

                    instance = Id;
                    break;
                }

                case SmartApp.Model.BrowseNames.Name:
                {
                    if (createOrReplace)
                    {
                        if (Name == null)
                        {
                            if (replacement == null)
                            {
                                Name = new BaseDataVariableState<string>(this);
                            }
                            else
                            {
                                Name = (BaseDataVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = Name;
                    break;
                }

                case SmartApp.Model.BrowseNames.Devices:
                {
                    if (createOrReplace)
                    {
                        if (Devices == null)
                        {
                            if (replacement == null)
                            {
                                Devices = new DeviceState(this);
                            }
                            else
                            {
                                Devices = (DeviceState)replacement;
                            }
                        }
                    }

                    instance = Devices;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseDataVariableState m_id;
        private BaseDataVariableState<string> m_name;
        private DeviceState m_devices;
        #endregion
    }
    #endif
    #endregion

    #region DeviceState Class
    #if (!OPCUA_EXCLUDE_DeviceState)
    /// <summary>
    /// Stores an instance of the Device ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class DeviceState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public DeviceState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(SmartApp.Model.ObjectTypes.Device, SmartApp.Model.Namespaces.SmartApp_Model, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACoAAABodHRwOi8vc2NyZWVuc2F2ZXIuY29tL1RQVU0vU21hcnRIb3VzZUFwcC//////BGCAAAEA" +
           "AAABAA4AAABEZXZpY2VJbnN0YW5jZQEBFgABARYA/////wQAAAAVYIkKAgAAAAEAAgAAAElkAQEXAAAv" +
           "AD8XAAAAABv/////AQH/////AAAAABVgiQoCAAAAAQAEAAAATmFtZQEBGAAALwA/GAAAAAAM/////wEB" +
           "/////wAAAAAVYIkKAgAAAAEABwAAAEVuYWJsZWQBARkAAC8APxkAAAAAAf////8BAf////8AAAAAFWCJ" +
           "CgIAAAABAAkAAABMYXN0U3RhdGUBARoAAC8APxoAAAAAAf////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Id Variable.
        /// </summary>
        public BaseDataVariableState Id
        {
            get
            {
                return m_id;
            }

            set
            {
                if (!Object.ReferenceEquals(m_id, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_id = value;
            }
        }

        /// <summary>
        /// A description for the Name Variable.
        /// </summary>
        public BaseDataVariableState<string> Name
        {
            get
            {
                return m_name;
            }

            set
            {
                if (!Object.ReferenceEquals(m_name, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_name = value;
            }
        }

        /// <summary>
        /// A description for the Enabled Variable.
        /// </summary>
        public BaseDataVariableState<bool> Enabled
        {
            get
            {
                return m_enabled;
            }

            set
            {
                if (!Object.ReferenceEquals(m_enabled, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_enabled = value;
            }
        }

        /// <summary>
        /// A description for the LastState Variable.
        /// </summary>
        public BaseDataVariableState<bool> LastState
        {
            get
            {
                return m_lastState;
            }

            set
            {
                if (!Object.ReferenceEquals(m_lastState, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_lastState = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_id != null)
            {
                children.Add(m_id);
            }

            if (m_name != null)
            {
                children.Add(m_name);
            }

            if (m_enabled != null)
            {
                children.Add(m_enabled);
            }

            if (m_lastState != null)
            {
                children.Add(m_lastState);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case SmartApp.Model.BrowseNames.Id:
                {
                    if (createOrReplace)
                    {
                        if (Id == null)
                        {
                            if (replacement == null)
                            {
                                Id = new BaseDataVariableState(this);
                            }
                            else
                            {
                                Id = (BaseDataVariableState)replacement;
                            }
                        }
                    }

                    instance = Id;
                    break;
                }

                case SmartApp.Model.BrowseNames.Name:
                {
                    if (createOrReplace)
                    {
                        if (Name == null)
                        {
                            if (replacement == null)
                            {
                                Name = new BaseDataVariableState<string>(this);
                            }
                            else
                            {
                                Name = (BaseDataVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = Name;
                    break;
                }

                case SmartApp.Model.BrowseNames.Enabled:
                {
                    if (createOrReplace)
                    {
                        if (Enabled == null)
                        {
                            if (replacement == null)
                            {
                                Enabled = new BaseDataVariableState<bool>(this);
                            }
                            else
                            {
                                Enabled = (BaseDataVariableState<bool>)replacement;
                            }
                        }
                    }

                    instance = Enabled;
                    break;
                }

                case SmartApp.Model.BrowseNames.LastState:
                {
                    if (createOrReplace)
                    {
                        if (LastState == null)
                        {
                            if (replacement == null)
                            {
                                LastState = new BaseDataVariableState<bool>(this);
                            }
                            else
                            {
                                LastState = (BaseDataVariableState<bool>)replacement;
                            }
                        }
                    }

                    instance = LastState;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseDataVariableState m_id;
        private BaseDataVariableState<string> m_name;
        private BaseDataVariableState<bool> m_enabled;
        private BaseDataVariableState<bool> m_lastState;
        #endregion
    }
    #endif
    #endregion
}